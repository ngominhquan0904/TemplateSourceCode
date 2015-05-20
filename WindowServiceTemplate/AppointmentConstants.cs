namespace WindowServiceTemplate
{
    public class AppointmentConstants
    {
        public static readonly string SEGMENT_DELIMITER = char.ConvertFromUtf32(13);
        public static readonly string MESSAGE_DELIMITER = char.ConvertFromUtf32(10);
        public const string FIELD_DELIMITER = "|";
        public const string ENCODING_CHARACTER = @"^~\&";

        /// <summary>
        /// 'C' - Client
        /// </summary>
        public const string CLIENT_BILL_TYPE_CODE = "C";

        /// <summary>
        /// LabCorp 's client ID
        /// </summary>
        public const string ACCOUNT_NO = "90021655";

        // LabCorp will provide in separate email account numbers assigned to Life Line to populate field MSH-3
        public const string SENDING_APP = "LLUSVCS";

        //LabCorp will provide in separate email account numbers assigned to Life Line to populate field MSH-4
        public const string SENDING_FACILITY = "TE025954";

        public const string RECEIVING_APPLICATION = "1100";

        public const string SENDING_APPLICATION_RESULT = "1100";

        public const string RECEIVING_APP_RESULT = "LLUSVCS";

        /// <summary>
        /// 'ORM' - Lab order message type code
        /// </summary>
        public const string ORDER_MESSAGE_TYPE = "ORM";

        public const string RESULT_MESSAGE_CODING_SYSTEM = "L";

        public const string RESULT_MESSAGE_ACTION_CODE = "N";

        /// <summary>
        /// Result message type
        /// </summary>
        public const string RESULT_MESSAGE_TYPE = "ORU";

        // LabCorp will provide in separate email account numbers assigned to Life Line to populate field MSH-6
        public const string RECEIVING_FACILITY = "TA";

        /// <summary>
        /// 'P' - To identify 'Production' order
        /// </summary>
        public const string PROCESSING_ID = "P";

        /// <summary>
        /// '2.3'
        /// </summary>
        public const string HL7_VERSION = "2.3";

        /// <summary>
        /// 'yyyyMMddHHmm'
        /// </summary>
        public const string DATE_TIME_FORMAT_WITH_MINUTE = "yyyyMMddHHmm";

        public const string DATE_FORMAT = "yyyyMMdd";

        /// <summary>
        /// 'NW' - New orders
        /// </summary>
        public const string ORDER_CONTROL_NEW = "NW";

        public const string RESULT_MESSAGE_CONTROL = "RE";

        public const string RESULT_MESSAGE_VALUE_TYPE = "TX";

        public const string RESULT_MESSAGE_PATIENT_BILL_TYPE = "C";

        /// <summary>
        /// 'N' - NPI Number
        /// </summary>
        public const string SOURCE_TABLE_NPI_NUMBER = "N";

        public const string FASTING_YES = "Y";
        public const string FASTING_NO = "N";
        public const string GENDER_FEMALE = "F";
        public const string GENDER_MALE = "M";
        public const string GENDER_NOT_INDICATED = "N";

        #region Race constants

        public const string RACE_ASIAN = "A"; // 'A' – Asian  
        public const string RACE_BLACK_OR_AFRICAN_AMERICAN = "B"; // 'B' - Black or African American
        public const string RACE_WHITE_CAUCASIAN = "C"; // 'C' - White, Caucasian
        public const string RACE_HISPANIC = "H"; // 'H' – Hispanic (for future use see PID-22 for Ethnicity) 
        public const string RACE_AMERICAN_INDIAN_OR_ALASKAN_NATIVE = "I"; // 'I' – American Indian or Alaskan Native  
        public const string RACE_OTHER_RACE = "O"; // 'O' - Other race
        public const string RACE_RACE_NOT_INDICATED = "X"; // 'X' – Race Not Indicated
        public const string RACE_ASHKENAZI_JEWISH = "J"; // 'J' – Ashkenazi Jewish (only for Integrated Genetics)  
        public const string RACE_SEPHARDIC_JEWISH = "S"; // 'S' – Sephardic Jewish (only for Integrated Genetics)

        #endregion Race constants

        #region MaxLength constants

        public const int MAX_NUMBER_OF_PRODUCTS = 40;

        public const int MSH4_LENGTH = 10;
        public const int PID_2_LENGTH = 20;
        public const int PID_4_LENGTH = 20;
        public const int PID_5_1_LENGTH = 25;
        public const int PID_5_2_LENGTH = 15;
        public const int PID_5_3_LENGTH = 15;
        public const int PID_11_1_LENGTH = 35;
        public const int PID_11_3_LENGTH = 16;
        //public const int PID_11_4_LENGTH = 2;
        //public const int PID_11_5_LENGTH = 9;
        public const int PID_13_LENGTH = 10;
        //public const int PID_18_1_LENGTH = 8;
        public const int ORC_2_1_LENGTH = 30;
        public const int ORC_12_1_LENGTH = 10;
        public const int ORC_12_2_LENGTH = 25;
        public const int ORC_12_3_LENGTH = 15;
        public const int OBR_4_1_LENGTH = 15;
        public const int OBR_4_2_LENGTH = 50;
        public const int OBR_7_LENGTH = 12;
        public const int OBR_13_1_LENGTH = 64;
        public const int OBR_16_1_LENGTH = 20;
        public const int OBR_16_2_LENGTH = 25;
        public const int OBR_16_3_LENGTH = 15;

        #endregion MaxLength constants
    }
}