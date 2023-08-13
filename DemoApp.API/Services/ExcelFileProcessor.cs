using DemoApp.API.Dto;
using DemoApp.API.Services.Interfaces;
using NPOI.XSSF.UserModel;

namespace DemoApp.API.Services
{
    public class ExcelFileProcessor : IExcelFileProcessor
    {
        public IEnumerable<AddCategoryRequestDto> GetCategories(IFormFile file)
        {
            List<AddCategoryRequestDto> categories = new List<AddCategoryRequestDto>();
            using(var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Position = 0;
                using(var workbook = new XSSFWorkbook(ms))
                {
                    var sheet = workbook.GetSheetAt(0);
                    for(int rowIdx = 1; rowIdx <= sheet.LastRowNum; rowIdx++)
                    {
                        var row = sheet.GetRow(rowIdx);
                        if(row is not null)
                        {
                            categories.Add(new AddCategoryRequestDto
                            {
                                Name = row.GetCell(0)?.ToString() ?? string.Empty,
                                Code = row.GetCell(1)?.ToString() ?? string.Empty,
                                Description = row.GetCell(2)?.ToString() ?? string.Empty

                            });
                        }
                    }     
                }
            }
            return categories;
        }
    }
}
