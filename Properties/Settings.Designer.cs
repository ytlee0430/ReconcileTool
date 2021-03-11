// Decompiled with JetBrains decompiler
// Type: ReconcileTool.Properties.Settings
// Assembly: ReconcileTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69F28CD3-7616-4019-A85A-62B543F52226
// Assembly location: E:\Git\ReconsileTool\ReconcileTool.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ReconcileTool.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}
