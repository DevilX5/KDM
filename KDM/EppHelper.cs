using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDM
{
    public class EppHelper
    {
        public static bool ExportByDt(string path, DataTable Dt, string SheetName = "Sheet1", bool WithTitle = true)
        {
            var result = false;
            FileInfo newFile = new FileInfo(path);
            if (newFile.Exists)
            {
                newFile.Delete(); 
                newFile = new FileInfo(path);
            }
            using (var pkg = new ExcelPackage(newFile))
            {
                var ws = pkg.Workbook.Worksheets.Add(SheetName);
                ws.Cells[1, 1].LoadFromDataTable(Dt, WithTitle);
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                pkg.Save();
                result = true;
            }
            return result;
        }

        public static bool ExportByModel<T>(string path, IEnumerable<T> ModelList, string SheetName = "Sheet1", bool WithTitle = true)
        {
            var result = false;
            FileInfo newFile = new FileInfo(path);
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(path);
            }
            using (var pkg = new ExcelPackage(newFile))
            {
                var ws = pkg.Workbook.Worksheets.Add(SheetName);
                ws.Cells[1, 1].LoadFromCollection<T>(ModelList, WithTitle);
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                pkg.Save();
                result = true;
            }
            return result;
        }
    }
}