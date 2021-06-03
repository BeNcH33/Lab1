using Lab1.Models;
using Lab1.Models.Security;
using Microsoft.AspNet.Identity;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class CreateExelController : Controller
    {
        public FileResult GetUsersReport()
        {
            // Путь к файлу с шаблоном
            string file_path_template =
           Server.MapPath("~/Content/Reports/report_template.xlsx");
            FileInfo fi = new FileInfo(file_path_template);
            //Путь к файлу с результатом
            string file_path = Server.MapPath("~/Content/Reports/report.xlsx");
            FileInfo fi_report = new FileInfo(file_path);
            //будем использовть библитотеку не для коммерческого использования
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //открываем файл с шаблоном
            using (ExcelPackage excelPackage = new ExcelPackage(fi))
            {
                //устанавливаем поля документа
                excelPackage.Workbook.Properties.Author = "Моржаков В.С.";
                excelPackage.Workbook.Properties.Title = "Список студентов в системе";
                excelPackage.Workbook.Properties.Subject = "Студенты системы";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //плучаем лист по имени.
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Лист1"];
                //получаем списко пользователей и в цикле заполняем лист данными
                int startLine = 3;
                RoomsDBContext db = new RoomsDBContext();

                foreach (var item in db.NewStudents.ToList())
                {
                    worksheet.Cells[startLine, 1].Value = startLine - 2;
                    worksheet.Cells[startLine, 2].Value = item.ID;
                    worksheet.Cells[startLine, 3].Value = item.Name;
                    worksheet.Cells[startLine, 4].Value = item.Surname;
                    worksheet.Cells[startLine, 5].Value = item.Otch;
                    worksheet.Cells[startLine, 6].Value = item.PasportSer;
                    worksheet.Cells[startLine, 7].Value = item.PasportNumber;
                    worksheet.Cells[startLine, 8].Value = item.Sex;
                    worksheet.Cells[startLine, 9].Value = item.Birthday;
                    worksheet.Cells[startLine, 10].Value = item.Town;
                    startLine++;
                }


                worksheet = excelPackage.Workbook.Worksheets["Лист2"];
                int startLine2 = 3;
                
                foreach (var item in db.Contracts.ToList())
                {
                    worksheet.Cells[startLine2, 1].Value = startLine2 - 2;
                    worksheet.Cells[startLine2, 2].Value = item.number;
                    worksheet.Cells[startLine2, 3].Value = item.DateIn;
                    worksheet.Cells[startLine2, 4].Value = item.DateOut;
                    worksheet.Cells[startLine2, 5].Value = item.Cost;
                    startLine2++;
                }

                worksheet = excelPackage.Workbook.Worksheets["Лист3"];
                int startLine3 = 3;

                foreach (var item in db.Violations.ToList())
                {
                    worksheet.Cells[startLine3, 1].Value = startLine2 - 2;
                    
                    worksheet.Cells[startLine3, 2].Value = item.Date;
                    startLine3++;
                }






                //созраняем в новое место
                excelPackage.SaveAs(fi_report);

                // Тип файла - content-type
                // Имя файла - необязательно
                // return File(file_path, file_type, file_name);

                MailAddress from = new MailAddress("slava.morzhakov@mail.ru", "Отчёт о работе");
                // кому отправляем
                MailAddress to = new MailAddress("eptsep@mail.ru");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Задание";
                // текст письма
                m.Body = "Отчет";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("slava.morzhakov@mail.ru", "25J7nMcp");
                smtp.EnableSsl = true;
                m.Attachments.Add(new Attachment(file_path));
                smtp.Send(m);
                return base.File(file_path, "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet", "report.xlsx");
            }
            // Тип файла - content-type
            string file_type = "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet";
            // Имя файла - необязательно
            string file_name = "report.xlsx";
            return File(file_path, file_type, file_name);
        }
        
    }
}