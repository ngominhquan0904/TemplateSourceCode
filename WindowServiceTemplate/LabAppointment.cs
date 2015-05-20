using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WindowServiceTemplate
{
    [DataContract]
    public class LabAppointment
    {
         /// <summary>
        /// yyyyMMDDHHmm
        /// </summary>
        [DataMember]
        public DateTime SpecmenDate { get; set; }

        [DataMember]
        public string AccountNo { get; set; }

        [DataMember]
        public string PhysicianName { get; set; } // delete- not use

        [DataMember]
        public string PhysicianState { get; set; } // Only for report

        [DataMember]
        public string SpecmenId { get; set; }

        [DataMember]
        public string MsgCreatedDate { get; set; }

        [DataMember]
        public string SendingFacility { get; set; }

        [DataMember]
        public string RelevantClinicalInformation { get; set; }

        /// <summary>
        /// PID.2
        /// Screening code
        /// </summary>
        [DataMember]
        public string ExternalPatientId { get; set; }

        /// <summary>
        /// PID.4
        /// Patient ID/SCANTRON #/Alt.ExternalPatientID
        /// Maxleng = 10 
        /// </summary>
        [DataMember]
        public string AltPatientId { get; set; }

        /// <summary>
        /// Maxlength 10; No dashes
        /// </summary>
        [DataMember]
        public string PatientPhoneNumber { get; set; }

        /// <summary>
        /// Patient Street Address or PO Box #
        /// </summary>
        [DataMember]
        public string FullPatientAddress { get; set; }

        [DataMember]
        public string PatientCity { get; set; }

        [DataMember]
        public string PatientState { get; set; }

        [DataMember]
        public string PatientZipCode { get; set; }

        /// <summary>
        /// 'A' – Asian  
        /// 'B' - Black or African American
        /// 'C' - White, Caucasian
        /// 'H' – Hispanic (for future use see PID-22 for Ethnicity) 
        /// 'I' – American Indian or Alaskan Native  
        /// 'O' - Other race
        /// 'X' – PatientRace Not Indicated
        /// 'J' – Ashkenazi Jewish (only for Integrated Genetics)  
        /// 'S' – Sephardic Jewish (only for Integrated Genetics) 
        /// </summary>
        [DataMember]
        public string PatientRace { get; set; }

        [DataMember]
        public string FastingFlag { get; set; }

        [DataMember]
        public string Gender { get; set; } // M: Male; F:Female; O: Other

        /// <summary>
        /// yyyyMMDD
        /// </summary>
        [DataMember]
        public DateTime DateofBirth { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PatientMiddleInitial { get; set; }

        [DataMember]
        public string OrderingProviderIdNumber { get; set; } // NPI no

        /// <summary>
        /// Family Name
        /// </summary>
        [DataMember]
        public string OrderingProviderLastName { get; set; }

        /// <summary>
        /// Given Name
        /// </summary>
        [DataMember]
        public string OrderingProviderFirstInitial { get; set; }

        [DataMember]
        public char SourceTable { get; set; }

//        [DataMember]
//        public List<Product> Products { get; set; }

        public LabAppointment(string accountNo, string sendingFacility, string msgCreatedDate)
        {
            AccountNo = accountNo;
            SendingFacility = sendingFacility;
            MsgCreatedDate = msgCreatedDate;
        }

        public LabAppointment()
        {
            //AccountNo = Constants.ACCOUNT_NO;
            AccountNo = "90021655";
            //SendingFacility = Constants.SENDING_FACILITY;
            SendingFacility = "TE025954";
            //public const string SENDING_FACILITY = "TE025954";
            //MsgCreatedDate = DateTimeOffset.UtcNow.ToString((string) Constants.DATE_TIME_FORMAT_WITH_MINUTE);
#warning check to setup value
//            Products = new List<Product>();
        } 
    }
}