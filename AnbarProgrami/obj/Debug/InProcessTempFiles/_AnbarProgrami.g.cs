//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XamlStaticHelperNamespace {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamlBuildTask", "4.0.0.0")]
    internal class _XamlStaticHelper {
        
        private static System.WeakReference schemaContextField;
        
        private static System.Collections.Generic.IList<System.Reflection.Assembly> assemblyListField;
        
        internal static System.Xaml.XamlSchemaContext SchemaContext {
            get {
                System.Xaml.XamlSchemaContext xsc = null;
                if ((schemaContextField != null)) {
                    xsc = ((System.Xaml.XamlSchemaContext)(schemaContextField.Target));
                    if ((xsc != null)) {
                        return xsc;
                    }
                }
                if ((AssemblyList.Count > 0)) {
                    xsc = new System.Xaml.XamlSchemaContext(AssemblyList);
                }
                else {
                    xsc = new System.Xaml.XamlSchemaContext();
                }
                schemaContextField = new System.WeakReference(xsc);
                return xsc;
            }
        }
        
        internal static System.Collections.Generic.IList<System.Reflection.Assembly> AssemblyList {
            get {
                if ((assemblyListField == null)) {
                    assemblyListField = LoadAssemblies();
                }
                return assemblyListField;
            }
        }
        
        private static System.Collections.Generic.IList<System.Reflection.Assembly> LoadAssemblies() {
            System.Collections.Generic.IList<System.Reflection.Assembly> assemblyList = new System.Collections.Generic.List<System.Reflection.Assembly>();
            assemblyList.Add(Load("Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a" +
                        "3a"));
            assemblyList.Add(Load("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364" +
                        "e35"));
            assemblyList.Add(Load("System.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKe" +
                        "yToken=31bf3856ad364e35"));
            assemblyList.Add(Load("System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11" +
                        "d50a3a"));
            assemblyList.Add(Load("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Data.DataSetExtensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b" +
                        "77a5c561934e089"));
            assemblyList.Add(Load("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Data.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0" +
                        "89"));
            assemblyList.Add(Load("System.Deployment, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50" +
                        "a3a"));
            assemblyList.Add(Load("System.DirectoryServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f" +
                        "7f11d50a3a"));
            assemblyList.Add(Load("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
                        ""));
            assemblyList.Add(Load("System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" +
                        "a"));
            assemblyList.Add(Load("System.ServiceModel.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=" +
                        "31bf3856ad364e35"));
            assemblyList.Add(Load("System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c56193" +
                        "4e089"));
            assemblyList.Add(Load("System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c5619" +
                        "34e089"));
            assemblyList.Add(Load("System.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e08" +
                        "9"));
            assemblyList.Add(Load("DevExpress.Charts.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b" +
                        "88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.Data.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754" +
                        "d700e49a"));
            assemblyList.Add(Load("DevExpress.DataAccess.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b8" +
                        "8d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.Office.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b" +
                        "88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.Pdf.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d" +
                        "1754d700e49a"));
            assemblyList.Add(Load("DevExpress.Pdf.v15.2.Drawing, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b" +
                        "88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.PivotGrid.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyToke" +
                        "n=b88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.Printing.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyToken" +
                        "=b88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.RichEdit.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyToken" +
                        "=b88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.Sparkline.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyToke" +
                        "n=b88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.Utils.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d175" +
                        "4d700e49a"));
            assemblyList.Add(Load("DevExpress.Utils.v15.2.UI, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d" +
                        "1754d700e49a"));
            assemblyList.Add(Load("DevExpress.Xpo.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d" +
                        "700e49a"));
            assemblyList.Add(Load("DevExpress.XtraBars.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d" +
                        "1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraCharts.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b8" +
                        "8d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraEditors.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b" +
                        "88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraGauges.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyTok" +
                        "en=b88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraGrid.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d" +
                        "1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraLayout.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b8" +
                        "8d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraPrinting.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=" +
                        "b88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraReports.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b" +
                        "88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraReports.v15.2.Extensions, Version=15.2.9.0, Culture=neutral, Publi" +
                        "cKeyToken=b88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraRichEdit.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=" +
                        "b88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraScheduler.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKey" +
                        "Token=b88d1754d700e49a"));
            assemblyList.Add(Load("DevExpress.XtraScheduler.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken" +
                        "=b88d1754d700e49a"));
            assemblyList.Add(Load("EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e08" +
                        "9"));
            assemblyList.Add(Load("EntityFramework.SqlServer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5" +
                        "c561934e089"));
            assemblyList.Add(Load("Excel.4.5, Version=2.1.2.0, Culture=neutral, PublicKeyToken=93517dbe6a4012fa"));
            assemblyList.Add(Load("ExcelDataReader, Version=3.2.0.0, Culture=neutral, PublicKeyToken=93517dbe6a4012f" +
                        "a"));
            assemblyList.Add(Load("Microsoft.Office.Interop.Excel, Version=15.0.0.0, Culture=neutral, PublicKeyToken" +
                        "=71e9bce111e9429c"));
            assemblyList.Add(Load("Microsoft.ReportViewer.Common, Version=11.0.0.0, Culture=neutral, PublicKeyToken=" +
                        "89845dcd8080cc91"));
            assemblyList.Add(Load("Microsoft.ReportViewer.ProcessingObjectModel, Version=11.0.0.0, Culture=neutral, " +
                        "PublicKeyToken=89845dcd8080cc91"));
            assemblyList.Add(Load("Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToke" +
                        "n=89845dcd8080cc91"));
            assemblyList.Add(Load("System.Data.SQLite, Version=1.0.105.2, Culture=neutral, PublicKeyToken=db937bc2d4" +
                        "4ff139"));
            assemblyList.Add(Load("System.Data.SQLite.EF6, Version=1.0.105.2, Culture=neutral, PublicKeyToken=db937b" +
                        "c2d44ff139"));
            assemblyList.Add(Load("System.Data.SQLite.Linq, Version=1.0.105.2, Culture=neutral, PublicKeyToken=db937" +
                        "bc2d44ff139"));
            assemblyList.Add(System.Reflection.Assembly.GetExecutingAssembly());
            return assemblyList;
        }
        
        private static System.Reflection.Assembly Load(string assemblyNameVal) {
            System.Reflection.AssemblyName assemblyName = new System.Reflection.AssemblyName(assemblyNameVal);
            byte[] publicKeyToken = assemblyName.GetPublicKeyToken();
            System.Reflection.Assembly asm = null;
            try {
                asm = System.Reflection.Assembly.Load(assemblyName.FullName);
            }
            catch (System.Exception ) {
                System.Reflection.AssemblyName shortName = new System.Reflection.AssemblyName(assemblyName.Name);
                if ((publicKeyToken != null)) {
                    shortName.SetPublicKeyToken(publicKeyToken);
                }
                asm = System.Reflection.Assembly.Load(shortName);
            }
            return asm;
        }
    }
}