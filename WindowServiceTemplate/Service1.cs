using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Logging;

namespace WindowServiceTemplate
{
    public partial class Service1 : ServiceBase
    {
//        private readonly string from = ConfigurationManager.AppSettings["DefaultFromEmail"];
//        private readonly string to = ConfigurationManager.AppSettings["DefaultToEmail"];
//        private const string Subject = "HL7 Edi Job service";
        private  ILog log;
        private  IEdiFtpService ftpService;
//        private readonly IEdiService ediService;
//        private readonly IEdiEmailService emailService;
        private readonly FSAFieldDBEntities fsaFieldDbEntities;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
          
            
        }

        protected override void OnStop()
        {
        }

        public void StartGenAppointmentList()
        {
            var labAppointment = SetupLabOrderObject();
            CreateHL7LabOrderMessageFile(labAppointment);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="labOrder"></param>
        /// <returns>Order location</returns>
        public string CreateHL7LabOrderMessageFile(LabAppointment labAppointment)
        {
            var ediAdapter = new AdapterEDI();
            ftpService = new EdiFtpService();
            var mes = ediAdapter.CreateLabAppointment(labAppointment);
            var fName = Utility.GetHL7OrderFileName(string.Format("{0}-{1}", labAppointment.AltPatientId, labAppointment.SpecmenId), DateTimeOffset.UtcNow);
            return ftpService.WriteOrderMessageFile(fName, mes);
        }
        private LabAppointment SetupLabOrderObject()
        {
            // define test data.
            var labOrder = new LabAppointment();

            labOrder.MsgCreatedDate = "201307251551";
            labOrder.AltPatientId = "PID1234567";
            labOrder.ExternalPatientId = "13-0423_AUS";
            labOrder.LastName = "Fiore";
            labOrder.FirstName = "Joseph";
            labOrder.PatientMiddleInitial = "N";
            labOrder.DateofBirth = new DateTime(1970, 7, 23); //23/07/1970
            labOrder.Gender = "M"; // Male
            labOrder.PatientRace = "A"; // Asian
            labOrder.FullPatientAddress = "4207 River Place BLVD, Austin, TX";
            labOrder.PatientCity = "Austin";
            labOrder.PatientState = "TX";
            labOrder.PatientZipCode = "787308009";
            labOrder.PatientPhoneNumber = "5129969555";
            labOrder.SpecmenId = "SID123456789";
            labOrder.OrderingProviderFirstInitial = "Ralph";
            labOrder.OrderingProviderLastName = "Gallo";
            labOrder.OrderingProviderIdNumber = "1255372876";
            labOrder.AccountNo = AppointmentConstants.ACCOUNT_NO;
            labOrder.FastingFlag = "Y";
            labOrder.SpecmenDate = new DateTime(2013, 7, 23, 13, 09, 0); //2013/07/23  13:09
            
            return labOrder;
        }

    }
}
