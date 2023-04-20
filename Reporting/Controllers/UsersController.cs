using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Web.Http;


namespace Reporting.Controllers
{
    public class UsersController : ApiController
    {
        private byte[] _contentBytes;
        private ReportDocument reportDocument;

        public byte[] Get()
        {
            reportDocument = new ReportDocument();
            reportDocument.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "UserReport.rpt"));

            reportDocument.SetDatabaseLogon("", "", @"AHMED-PC\\SQLEXPRESS", "Braincrop");

            _contentBytes = StreamToBytes(reportDocument.ExportToStream(ExportFormatType.PortableDocFormat));
            return _contentBytes;
        }

        public byte[] Get(int? id)
        {
            if (id == null)
            {
                return null;
            }

            reportDocument = new ReportDocument();
            reportDocument.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "IndividualUserReport.rpt"));
            reportDocument.SetDatabaseLogon("", "", @"AHMED-PC\\SQLEXPRESS", "Braincrop");
            reportDocument.SetParameterValue("userId", id);

            _contentBytes = StreamToBytes(reportDocument.ExportToStream(ExportFormatType.PortableDocFormat));
            return _contentBytes;
        }

        public static byte[] StreamToBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}