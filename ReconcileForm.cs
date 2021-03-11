using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReconcileTool
{
    public partial class ReconcileForm : Form
    {
        private bool _isCreditCard = false;
        private List<string> _noneMatchNames = new List<string>();
        private string _shoppeFile;
        private string _stockFile;
        private int _accountIndex;
        private int _originialProductMoneyIndex;
        private int _discountMoneyIndex;
        private int _buyerTransportMoneyIndex;
        private string _finalPath;
        private Button btnLoadShoppeData;
        private OpenFileDialog ofdLoadShoppeData;
        private Button btnLoadStockInfo;
        private OpenFileDialog ofdLoadStockData;
        private Button button2;
        private TextBox tbxFileName;
        private TextBox tbxNoneMatchNames;
        private Label label1;
        private Label label2;
        private TextBox tbxFindAccount;
        private Label label3;

        public ReconcileForm()
        {
            DateTime now = DateTime.Now;
            DateTime dateTime = now.AddMonths(1);
            int year = dateTime.Year;
            dateTime = now.AddMonths(1);
            int month = dateTime.Month;
            dateTime = new DateTime(year, month, 1);
            dateTime.AddDays(-1.0).Subtract(now);
            this.InitializeComponent();
        }

        private void btnLoadStockInfo_Click(object sender, EventArgs e)
        {
            int num = (int)this.ofdLoadStockData.ShowDialog();
        }

        private void btnLoadShoppeData_Click(object sender, EventArgs e)
        {
            int num = (int)this.ofdLoadShoppeData.ShowDialog();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            this._shoppeFile = this.ofdLoadShoppeData.FileName;
            if (this._shoppeFile == "")
            {
                int num1 = (int)MessageBox.Show("請先選擇蝦皮入帳資料檔案");
            }
            else
            {
                this._stockFile = this.ofdLoadStockData.FileName;
                if (this._stockFile == "")
                {
                    int num2 = (int)MessageBox.Show("請先選擇進出存銷資料檔案");
                }
                else
                {
                    StreamReader sr = new StreamReader((Stream)new FileStream(this._stockFile, FileMode.Open, FileAccess.Read, FileShare.None), Encoding.GetEncoding("Big5"));
                    List<AccountModel> analyzeResult = this.analyzeData(sr);
                    sr.Close();
                    sr.Dispose();
                    this.creatNewExcel(this.addModelToShoppeData(analyzeResult));
                    int num3 = (int)MessageBox.Show("工作已完成");
                    this.tbxFileName.Text = this._finalPath;
                    this.tbxNoneMatchNames.Text = string.Join(" ,  ", (IEnumerable<string>)this._noneMatchNames);
                }
            }
        }

        private void creatNewExcel(List<List<string>> finals)
        {
            try
            {
                Dictionary<int, List<string>> source = new Dictionary<int, List<string>>();
                foreach (List<string> final in finals)
                {
                    string str = final[0];
                    source.Add(Convert.ToInt32(str), final);
                }
                List<string> stringList = new List<string>()
        {
          "編號",
          "訂單編號",
          "買家帳號",
          "訂單成立時間",
          "撥款完成日期",
          "商品原價",
          "你的賣家商品促銷",
          "買家支付的運費",
          "蝦皮運費補助",
          "成交手續費",
          "蝦皮代付運費",
          "信用卡手續費",
          "全部入帳金額 ($)",
          "發票",
          "送貨單編號",
          "產品明細"
        };
                source.Add(0, stringList);
                IOrderedEnumerable<KeyValuePair<int, List<string>>> orderedEnumerable = source.OrderBy<KeyValuePair<int, List<string>>, int>((Func<KeyValuePair<int, List<string>>, int>)(x => x.Key));
                this._finalPath = Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_蝦皮合併明細.csv";
                StreamWriter streamWriter = new StreamWriter((Stream)new FileStream(this._finalPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None), Encoding.UTF8);
                foreach (KeyValuePair<int, List<string>> keyValuePair in (IEnumerable<KeyValuePair<int, List<string>>>)orderedEnumerable)
                {
                    string str = string.Join(",", (IEnumerable<string>)keyValuePair.Value);
                    streamWriter.WriteLine(str);
                }
                streamWriter.Close();
                streamWriter.Dispose();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private List<List<string>> addModelToShoppeData(List<AccountModel> analyzeResult)
        {
            FileStream fileStream = new FileStream(this._shoppeFile, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader streamReader = new StreamReader((Stream)fileStream, Encoding.GetEncoding("Big5"));
            List<string> stringList = new List<string>();
            int num = 0;
            while (!streamReader.EndOfStream)
            {
                string str = streamReader.ReadLine();
                ++num;
                string[] strArray = str.Split(',');
                if (str.Contains("編號"))
                {
                    List<string> list = ((IEnumerable<string>)str.Replace(" ", string.Empty).Split(',')).ToList<string>();
                    this._accountIndex = list.IndexOf("買家帳號");
                    this._originialProductMoneyIndex = list.IndexOf("商品原價");
                    this._discountMoneyIndex = list.IndexOf("你的賣家商品促銷");
                    this._buyerTransportMoneyIndex = list.IndexOf("買家支付的運費");
                }
                if (str.Contains("信用卡手續費"))
                    this._isCreditCard = true;
                if (num == 7)
                    stringList.Clear();
                else if (num < 5 || !(strArray[0] == ""))
                    stringList.Add(str);
                else
                    break;
            }
            List<List<string>> stringListList = new List<List<string>>();
            if (this._isCreditCard)
            {
                foreach (string str1 in stringList)
                {
                    string[] strArray = str1.Split(',');
                    string account = strArray[this._accountIndex].Trim();
                    string str2 = strArray[this._originialProductMoneyIndex];
                    string str3 = strArray[this._buyerTransportMoneyIndex];
                    string str4 = "0";
                    if (!string.IsNullOrEmpty(strArray[this._discountMoneyIndex]))
                        str4 = strArray[this._discountMoneyIndex];
                    Convert.ToInt32(Convert.ToDecimal(str2) + Convert.ToDecimal(str4) + Convert.ToDecimal(str3)).ToString();
                    AccountModel accountModel = analyzeResult.FirstOrDefault<AccountModel>((Func<AccountModel, bool>)(x => x.Account == account));
                    if (accountModel == null)
                        this._noneMatchNames.Add(account);
                    if (accountModel != null)
                    {
                        List<string> list = ((IEnumerable<string>)str1.Split(',')).ToList<string>();
                        list.Add(accountModel.Receipt);
                        list.Add(accountModel.DeliveryNumber);
                        list.Add(accountModel.Products);
                        stringListList.Add(list);
                    }
                }
            }
            else
            {
                foreach (string str in stringList)
                {
                    string[] strArray = str.Split(',');
                    string account = strArray[1].Trim();
                    int totalMoney = Convert.ToInt32(strArray[9]) + Convert.ToInt32(strArray[5]) + Math.Abs(Convert.ToInt32(strArray[7]));
                    AccountModel accountModel = analyzeResult.Find((Predicate<AccountModel>)(x =>
                    {
                        if (x.Account == account)
                            return x.totalMoney == totalMoney.ToString();
                        return false;
                    }));
                    if (accountModel != null)
                    {
                        List<string> list = ((IEnumerable<string>)str.Split(',')).ToList<string>();
                        list.Add(accountModel.Receipt);
                        list.Add(accountModel.DeliveryNumber);
                        list.Add(accountModel.Products);
                        stringListList.Add(list);
                    }
                }
            }
            streamReader.Close();
            streamReader.Dispose();
            fileStream.Close();
            fileStream.Dispose();
            return stringListList;
        }

        private AccountModel setDataToModel(List<string> analyzes)
        {
            AccountModel accountModel = new AccountModel();
            try
            {
                string[] strArray1 = analyzes.First<string>().Split(',');
                string str1 = strArray1[1];
                string str2;
                if (strArray1[4].Contains("-"))
                    str2 = ((IEnumerable<string>)strArray1[4].Split('-')).Last<string>().Trim();
                else
                    str2 = strArray1[4];
                string str3 = string.Empty;
                string str4 = string.Empty;
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string analyz in analyzes)
                {
                    if (analyz.Contains("稅額"))
                    {
                        List<string> list = ((IEnumerable<string>)analyz.Split(',')).ToList<string>();
                        int index = list.IndexOf("稅額") + 1;
                        string[] strArray2 = list[index].Split('-');
                        str3 = strArray2[1].Trim();
                        str4 = ((IEnumerable<string>)strArray2).Last<string>().Trim();
                    }
                    if (!analyz.Contains("稅額") && !analyz.Contains("發票編號") && !analyz.Contains("運費"))
                    {
                        string str5 = analyz.Split(',')[3].Trim();
                        stringBuilder.Append(str5);
                        stringBuilder.Append(",");
                    }
                }
                return new AccountModel()
                {
                    DeliveryNumber = str1,
                    Account = str2,
                    Receipt = str3,
                    totalMoney = str4,
                    Products = stringBuilder.ToString()
                };
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private List<AccountModel> analyzeData(StreamReader sr)
        {
            List<AccountModel> accountModelList = new List<AccountModel>();
            try
            {
                string str = "";
                int num = 0;
                List<string> analyzes = new List<string>();
                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                    ++num;
                    if (num > 9)
                    {
                        analyzes.Add(str);
                        if (str.Contains("發票編號:"))
                        {
                            AccountModel model = this.setDataToModel(analyzes);
                            if (model != null)
                                accountModelList.Add(model);
                            analyzes.Clear();
                        }
                    }
                }
                sr.Close();
                Console.WriteLine(str);
            }
            catch (Exception ex)
            {
                int num1 = (int)MessageBox.Show("分析進銷存資料錯誤");
                int num2 = (int)MessageBox.Show(ex.ToString());
                throw;
            }
            return accountModelList;
        }
    }
}
