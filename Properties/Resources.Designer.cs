﻿// Decompiled with JetBrains decompiler
// Type: ReconcileTool.Properties.Resources
// Assembly: ReconcileTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69F28CD3-7616-4019-A85A-62B543F52226
// Assembly location: E:\Git\ReconsileTool\ReconcileTool.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ReconcileTool.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (ReconcileTool.Properties.Resources.resourceMan == null)
          ReconcileTool.Properties.Resources.resourceMan = new ResourceManager("ReconcileTool.Properties.Resources", typeof (ReconcileTool.Properties.Resources).Assembly);
        return ReconcileTool.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return ReconcileTool.Properties.Resources.resourceCulture;
      }
      set
      {
        ReconcileTool.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
