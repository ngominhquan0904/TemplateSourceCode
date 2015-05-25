using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EDIParser;
using ServiceStack.Logging;

namespace WindowServiceTemplate
{
    public class AdapterEDI
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AdapterEDI).Name);
        private ILabAppointmentValidator labOrderValidator;

        public AdapterEDI()
        {
            labOrderValidator = new LabAppointmentValidator();
        }

        public AdapterEDI(ILabAppointmentValidator _labOrderValidator)
        {
            labOrderValidator = _labOrderValidator;
        }
        public string CreateLabAppointment(LabAppointment labAppointment)
        {
            // Validating input data
            if (labAppointment == null)
            {
                log.Error("CreateLabOrder(labAppointment labAppointment) not accept null parameter.");
                throw new ArgumentNullException("labAppointment");
            }

//            labAppointment = TruncateExessCharacter(labAppointment); // truncate characters that exceed maxlength
            labAppointment = CleanSpecialCharacter(labAppointment);

            string validateErr = ValidateAppointmentInfor(labAppointment);
            if (validateErr.Length != 0)
            {
                log.Error(validateErr);
                throw new InvalidDataException(validateErr);
            }

            var hl7 = new HL7Parser();
            hl7.SegmentSeparator = AppointmentConstants.SEGMENT_DELIMITER;

            // Header segment
            hl7.SetValue("MSH.1", AppointmentConstants.FIELD_DELIMITER);
            hl7.SetValue("MSH.2", AppointmentConstants.ENCODING_CHARACTER);
            hl7.SetValue("MSH.3", AppointmentConstants.SENDING_APP);
            //hl7.SetValue("MSH.4", AppointmentConstants.SENDING_FACILITY);
            hl7.SetValue("MSH.4", labAppointment.SendingFacility);
            hl7.SetValue("MSH.5", AppointmentConstants.RECEIVING_APPLICATION);
            hl7.SetValue("MSH.6", AppointmentConstants.RECEIVING_FACILITY);

            hl7.SetValue("MSH.7", labAppointment.MsgCreatedDate); // Datetime create electronic order
            hl7.SetValue("MSH.9", AppointmentConstants.ORDER_MESSAGE_TYPE);
            hl7.SetValue("MSH.11", AppointmentConstants.PROCESSING_ID);
            hl7.SetValue("MSH.12", AppointmentConstants.HL7_VERSION);

            // PID segment
            hl7.SetValue("PID.1", "1");
            hl7.SetValue("PID.2", labAppointment.ExternalPatientId);
            hl7.SetValue("PID.4", labAppointment.AltPatientId);
            hl7.SetValue("PID.5.1", labAppointment.LastName);
            hl7.SetValue("PID.5.2", labAppointment.FirstName);
            hl7.SetValue("PID.5.3", labAppointment.PatientMiddleInitial);
            hl7.SetValue("PID.7.1", labAppointment.DateofBirth.ToString(AppointmentConstants.DATE_FORMAT));
            hl7.SetValue("PID.8", labAppointment.Gender);
            hl7.SetValue("PID.10", labAppointment.PatientRace);
            hl7.SetValue("PID.11.1", labAppointment.FullPatientAddress);
            hl7.SetValue("PID.11.3", labAppointment.PatientCity);
            hl7.SetValue("PID.11.4", labAppointment.PatientState);
            hl7.SetValue("PID.11.5", labAppointment.PatientZipCode);
            hl7.SetValue("PID.13", labAppointment.PatientPhoneNumber);
            hl7.SetValue("PID.18.1", labAppointment.AccountNo);
            hl7.SetValue("PID.18.4", AppointmentConstants.CLIENT_BILL_TYPE_CODE);

            // PID segment end
            //=========================================================================================================

            // Fasting flag
            hl7.SetValue("NTE.1", "1");
            hl7.SetValue("NTE.2", "P");
            hl7.SetValue("NTE.3.1", "FSTING");
            hl7.SetValue("NTE.3.2", "FASTING");
            hl7.SetValue("NTE.5", labAppointment.FastingFlag);
            hl7.SetValue("NTE.10", "N");
            hl7.SetValue("NTE.11", "F");

//            // ORC-OBR segment begin
//
//            //  ORC Segment - Common Order Segment
//            // OBR Segment – Observation Order
//            if (labAppointment.Products != null && labAppointment.Products.Count != 0)
//            {
//                int productCount = 0;
//                productCount = labAppointment.Products.Count;
//
//                for (int productindex = 0; productindex < productCount; productindex++)
//                {
//                    int segmentIndex = productindex + 1;
//
//                    hl7.SetValue("ORC.1.1", AppointmentConstants.ORDER_CONTROL_NEW, segmentIndex);
//                    hl7.SetValue("ORC.2.1", labAppointment.SpecmenId, segmentIndex);
//                    hl7.SetValue("ORC.12.1", labAppointment.OrderingProviderIdNumber, segmentIndex);
//                    hl7.SetValue("ORC.12.2", labAppointment.OrderingProviderLastName, segmentIndex);
//                    hl7.SetValue("ORC.12.3", labAppointment.OrderingProviderFirstInitial, segmentIndex);
//                    hl7.SetValue("ORC.12.8", AppointmentConstants.SOURCE_TABLE_NPI_NUMBER, segmentIndex);
//
//                    // OBR segment
//                    Product itemProduct = labAppointment.Products[productindex];
//
//                    hl7.SetValue("OBR.1.1", segmentIndex.ToString(), segmentIndex);
//                    hl7.SetValue("OBR.2.1", labAppointment.SpecmenId, segmentIndex);
//
//                    hl7.SetValue("OBR.4.1", itemProduct.LabCorpOrderCode, segmentIndex);
//                    hl7.SetValue("OBR.4.2", itemProduct.TestOrderName, segmentIndex);
//                    hl7.SetValue("OBR.4.3", itemProduct.CodingSystem, segmentIndex);
//                    hl7.SetValue("OBR.7.1", labAppointment.SpecmenDate.ToString(AppointmentConstants.DATE_TIME_FORMAT_WITH_MINUTE),
//                        segmentIndex);
//                    hl7.SetValue("OBR.11.1", itemProduct.ActionCode, segmentIndex);
//                    hl7.SetValue("OBR.13.1", labAppointment.RelevantClinicalInformation, segmentIndex);
//                    hl7.SetValue("OBR.16.1", labAppointment.OrderingProviderIdNumber, segmentIndex);
//                    hl7.SetValue("OBR.16.2", labAppointment.OrderingProviderLastName, segmentIndex);
//                    hl7.SetValue("OBR.16.3", labAppointment.OrderingProviderFirstInitial, segmentIndex);
//
//                    hl7.SetValue("OBR.16.8", itemProduct.SourceTable, segmentIndex);
//                }
//            }
//
//            // ORC-OBR segment end

            return string.Format("{0}{1}", hl7.Message(), char.ConvertFromUtf32(10));
        }
        /// <summary>
        /// Validate inut data for create lab order message: Required and length
        /// </summary>
        /// <param name="labOrder">lab order infor</param>
        /// <returns>empty string: input data is correct; error message: input data is not correct</returns>
        private string ValidateAppointmentInfor(LabAppointment labOrder)
        {
            var MessageBuilder = new StringBuilder();

            //MSH.4 - Required-10 length
            MessageBuilder.Append(labOrderValidator.OrderSendingFacilityValidate(labOrder.SendingFacility));

            // PID.2.1
            MessageBuilder.Append(labOrderValidator.OrderExternalPatientIdValidate(labOrder.ExternalPatientId));

            //PID.4.1
            MessageBuilder.Append(labOrderValidator.OrderAltPatientIdValidate(labOrder.AltPatientId));

            //PID.5.1 - 25 alpha characters
            MessageBuilder.Append(labOrderValidator.OrderLastNameValidate(labOrder.LastName));

            //PID.5.2 - 15 characters
            MessageBuilder.Append(labOrderValidator.OrderFirstNameValidate(labOrder.FirstName));

            //PID.5.3 - 15 characters
            MessageBuilder.Append(labOrderValidator.OrderMidleNameValidate(labOrder.PatientMiddleInitial));

            //PID.7.1 - 8 length - convert from datetime
            // do not validate

            //PID.8.1 - 1 char
            MessageBuilder.Append(labOrderValidator.OrderGenderValidate(labOrder.Gender));

            //PID.10 - 1 char
            MessageBuilder.Append(labOrderValidator.OrderRaceValidate(labOrder.PatientRace, false));

            //PID,11,1 - 35 char
            MessageBuilder.Append(labOrderValidator.OrderPatientAddressValidate(labOrder.FullPatientAddress));

            //PID.11.3 - 16 chars
            MessageBuilder.Append(labOrderValidator.OrderCityValidate(labOrder.PatientCity));

            // PID.11.4 - 2 chars
            MessageBuilder.Append(labOrderValidator.OrderStateValidate(labOrder.PatientState));

            //PID.11.5 - 9 chars
            MessageBuilder.Append(labOrderValidator.OrderPatientZipCodeValidate(labOrder.PatientZipCode));

            //PID.13 - 10 chars
            MessageBuilder.Append(labOrderValidator.OrderPatientPhoneValidate(labOrder.PatientPhoneNumber));

            // PID.18.1 - 8 digrit numeric characters-Required
            MessageBuilder.Append(labOrderValidator.OrderAccountValidate(labOrder.AccountNo));

            // NTE.5.1 - 1
            MessageBuilder.Append(labOrderValidator.OrderFastingFlagValidate(labOrder.FastingFlag));

//            //ORC.2.1 - 30
//            MessageBuilder.Append(labOrderValidator.OrderSpecmenIdValidate(labOrder.SpecmenId));
//
//            //ORC.12.1 - 10
//            MessageBuilder.Append(labOrderValidator.OrderOrderingProviderIdValidate(labOrder.OrderingProviderIdNumber));
//
//            //ORC.12.2 - 25
//            MessageBuilder.Append(labOrderValidator.OrderOrderingProviderLastNameValidate(labOrder.OrderingProviderLastName));
//
//            //ORC.12.3 - 15
//            MessageBuilder.Append(
//                labOrderValidator.OrderOrderingProviderFirstInitialValidate(labOrder.OrderingProviderFirstInitial,
//                    labOrder.OrderingProviderLastName));
//
//            // OBR.2.1- SpecmentID -already validated on ORC
//            // OBR.13.1 - 64
//            MessageBuilder.Append(labOrderValidator.OrderRelevantClinicalValidate(labOrder.RelevantClinicalInformation));
//
//            // validate products information
//            int productCount = 0;
//            if (labOrder.Products != null)
//            {
//                productCount = labOrder.Products.Count;
//            }
//
//            // At this time, only 40 orders are supported. Any more OBR added will be ignored.
//            MessageBuilder.Append(labOrderValidator.OrderProductCountValidate(productCount));
//
//            if (labOrder.Products != null && productCount != 0)
//            {
//                for (int index = 0; index < productCount; index++)
//                {
//                    Product product = labOrder.Products[index];
//
//                    // OBR.4.1 - 15 alpha, numeric or special characters - required
//                    MessageBuilder.Append(labOrderValidator.OrderLabCorpOrderCodeValidate(product.LabCorpOrderCode, index));
//
//                    // OBR.4.2 - 50
//                    MessageBuilder.Append(labOrderValidator.OrderTestOrderNameValidate(product.TestOrderName, index));
//
//                    // OBR.4.3 - maxlength 2- required. 
//                    // 'L'- Local Identifier (LabCorp Identifier)
//
//                    //OBR.11 - maxlength 1- Required
//                    // 'N' - New orders accompanying new specimen (original order)
//                }
//            }

            string errorMessage = MessageBuilder.ToString();
            if (errorMessage.Length != 0)
            {
                errorMessage = string.Format("Input data error:{0}{1}", Environment.NewLine, errorMessage);
            }

            return errorMessage;
        }
        /// <summary>
        /// Truncate characters that exceed maxlength
        /// </summary>
        /// <param name="labOrder"></param>
        /// <returns></returns>
//        private LabAppointment TruncateExessCharacter(LabAppointment labOrder)
//        {
//            //labOrder.SendingFacility = TruncateToLength(labOrder.SendingFacility,Constants.MSH4_LENGTH);
//
//            if (labOrder.Products != null)
//            {
//                for (int index = 0; index < labOrder.Products.Count; index++)
//                {
//                    labOrder.Products[index].TestOrderName = TruncateToLength(labOrder.Products[index].TestOrderName, Constants.OBR_4_2_LENGTH);
//                }
//            }
//            return labOrder;
//        }
        /// <summary>
        /// Use escape character to display special character in HL7 message: ~^|
        /// </summary>
        /// <param name="labOrder"></param>
        /// <returns></returns>
        private LabAppointment CleanSpecialCharacter(LabAppointment labOrder)
        {
            labOrder.AltPatientId = Utility.EscapeSpecialCharacter(labOrder.AltPatientId);
            labOrder.ExternalPatientId = Utility.EscapeSpecialCharacter(labOrder.ExternalPatientId);
            labOrder.LastName = Utility.EscapeSpecialCharacter(labOrder.LastName);
            labOrder.FirstName = Utility.EscapeSpecialCharacter(labOrder.FirstName);
            labOrder.PatientMiddleInitial = Utility.EscapeSpecialCharacter(labOrder.PatientMiddleInitial);
            labOrder.FullPatientAddress = Utility.EscapeSpecialCharacter(labOrder.FullPatientAddress);
            labOrder.PatientCity = Utility.EscapeSpecialCharacter(labOrder.PatientCity);
            labOrder.PatientState = Utility.EscapeSpecialCharacter(labOrder.PatientState);
            labOrder.PatientZipCode = Utility.EscapeSpecialCharacter(labOrder.PatientZipCode);
            labOrder.PatientPhoneNumber = Utility.EscapeSpecialCharacter(labOrder.PatientPhoneNumber);
            labOrder.AccountNo = Utility.EscapeSpecialCharacter(labOrder.AccountNo);

            labOrder.RelevantClinicalInformation = Utility.EscapeSpecialCharacter(labOrder.RelevantClinicalInformation);
            labOrder.OrderingProviderIdNumber = Utility.EscapeSpecialCharacter(labOrder.OrderingProviderIdNumber);
            labOrder.OrderingProviderLastName = Utility.EscapeSpecialCharacter(labOrder.OrderingProviderLastName);
            labOrder.OrderingProviderFirstInitial = Utility.EscapeSpecialCharacter(labOrder.OrderingProviderFirstInitial);
            labOrder.SpecmenId = Utility.EscapeSpecialCharacter(labOrder.SpecmenId);

            labOrder.OrderingProviderIdNumber = Utility.EscapeSpecialCharacter(labOrder.OrderingProviderIdNumber);
            labOrder.OrderingProviderLastName = Utility.EscapeSpecialCharacter(labOrder.OrderingProviderLastName);
            labOrder.OrderingProviderFirstInitial = Utility.EscapeSpecialCharacter(labOrder.OrderingProviderFirstInitial);

            //  ORC Segment - Common Order Segment
            // OBR Segment – Observation Order
//            if (labOrder.Products != null && labOrder.Products.Count != 0)
//            {
//                foreach (Product itemProduct in labOrder.Products)
//                {
//                    itemProduct.TestOrderName = Utility.EscapeSpecialCharacter(itemProduct.TestOrderName);
//                    itemProduct.LabCorpOrderCode = Utility.EscapeSpecialCharacter(itemProduct.LabCorpOrderCode);
//                }
//            }

            return labOrder;
        }
    }
}