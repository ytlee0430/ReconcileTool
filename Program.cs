// Decompiled with JetBrains decompiler
// Type: ReconcileTool.Program
// Assembly: ReconcileTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69F28CD3-7616-4019-A85A-62B543F52226
// Assembly location: E:\Git\ReconsileTool\ReconcileTool.exe

using System;
using System.Windows.Forms;

namespace ReconcileTool
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new ReconcileForm());
    }
  }
}
