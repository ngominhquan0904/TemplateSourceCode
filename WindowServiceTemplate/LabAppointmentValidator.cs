using System;
using System.Text.RegularExpressions;

namespace WindowServiceTemplate
{
    public class LabAppointmentValidator : ILabAppointmentValidator
    {
        /// <summary>
        /// Validate a string is only contain alpha characters or not
        /// </summary>
        /// <param name="alphaCharacter">string to be validate</param>
        /// <returns>true: alpha character only; false: Not only alpha characters</returns>
        private static bool IsAlphaCharacter(string alphaCharacter)
        {
            // allow space between alpha character. Eg: New ork
            const string alPhaRegex = @"^[a-zA-Z]*[a-zA-Z]*$|^[a-zA-Z]+[ a-zA-Z]*[a-zA-Z]+$";
            bool isAlpha = Regex.IsMatch(alphaCharacter, alPhaRegex);

            return isAlpha;
        }

        #region Validate Lab Order information

        /// <summary>
        /// Validate MSH.4 Sending facility input data
        /// </summary>
        /// <param name="sendingFacility">input data</param>
        /// <returns>
        /// Empty string when input data is validate. 
        /// Error message when input data is invalidate</returns>
        public string OrderSendingFacilityValidate(string sendingFacility)
        {
            string msg = string.Empty;
            //MSH.4 - Required-10 length
            if (sendingFacility.Length == 0)
            {
                msg = string.Format(MsgResource.M0001, Environment.NewLine);
            }
            else if (sendingFacility.Length > AppointmentConstants.MSH4_LENGTH)
            {
                msg = string.Format(MsgResource.M0002, sendingFacility, Environment.NewLine);
            }
            return msg;
        }

        /// <summary>
        /// PID.2
        /// Not required for lab order
        /// LCA Length: Max 20 Alpha, Numeric, or Special Characters  
        /// External Patient ID 
        /// Use:  Client assigned Patient Identifier 
        /// Required for Billing 
        /// Depending on reporting setups, PID-2 and PID-4 could be returned in 
        /// different fields.  PID-2 could be returned in PID-4 and vice versa. 
        /// </summary>
        /// <param name="ExternalPatientId"></param>
        /// <returns></returns>
        public string OrderExternalPatientIdValidate(string ExternalPatientId)
        {
            string msg = string.Empty;
            // PID.2
            if (ExternalPatientId != null && ExternalPatientId.Length > AppointmentConstants.PID_2_LENGTH)
            {
                msg = string.Format(MsgResource.M0032, Environment.NewLine);
            }
            return msg;
        }

        /// <summary>
        /// PID.4
        /// Optional
        ///  Alternate Patient ID  
        ///  Use: Client assigned Patient Identifier 
        ///  LCA Length: Max 10 Alpha, Numeric, or Special Characters 
        ///  Depending on reporting setups, PID-2 and PID-4 could be returned in 
        ///  different fields.  PID-2 could be returned in PID-4 and vice versa. 
        /// </summary>
        /// <param name="alternatePatientId"></param>
        /// <returns></returns>
        public string OrderAltPatientIdValidate(string alternatePatientId)
        {
            string msg = string.Empty;

            //PID.4.1
            if (alternatePatientId.Length > AppointmentConstants.PID_4_LENGTH)
            {
                msg = string.Format(MsgResource.M0003, alternatePatientId, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// PID.5.1 
        /// Patient Last Name 
        /// Use:  Patient identifier 
        /// LCA Length: 25 Alpha Characters 
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public string OrderLastNameValidate(string lastName)
        {
            string msg = string.Empty;

            //PID.5.1 - 25 alpha characters
            if (lastName.Length == 0)
            {
                msg = string.Format(MsgResource.M0033, Environment.NewLine);
            }
            else if (!IsAlphaCharacter(lastName))
            {
                msg = string.Format(MsgResource.M0026, lastName, Environment.NewLine);
            }
            else if (lastName.Length > AppointmentConstants.PID_5_1_LENGTH)
            {
                msg = string.Format(MsgResource.M0004, lastName, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// PID.5.2 
        /// Patient First Name 
        /// Use:  Patient identifier 
        /// LCA Length: max 15 Alpha Characters 
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public string OrderFirstNameValidate(string firstName)
        {
            string msg = string.Empty;

            //PID.5.2 - 15 characters

            if (firstName.Length > AppointmentConstants.PID_5_2_LENGTH)
            {
                msg = string.Format(MsgResource.M0005, firstName, Environment.NewLine);
            }
            else if (firstName.Length == 0)
            {
                msg = string.Format("{0}{1}", MsgResource.M0034, Environment.NewLine);
            }
            else if (!IsAlphaCharacter(firstName))
            {
                msg = string.Format(MsgResource.M0027, firstName, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// PID.5.3 
        /// Optional
        /// Patient Middle Name 
        /// Use:  Patient identifier 
        /// LCA Length:max 15 Alpha Characters 
        /// 
        /// </summary>
        /// <param name="midleName"></param>
        /// <returns></returns>
        public string OrderMidleNameValidate(string midleName)
        {
            //PID.5.3 - 15 characters
            string msg = string.Empty;

            //const string midleNameRegex = @"^[a-zA-Z]{0,15}$";
            //if (!Regex.IsMatch(midleName, midleNameRegex))
            //{
            //}

            if (midleName.Length > AppointmentConstants.PID_5_3_LENGTH)
            {
                msg = string.Format(MsgResource.M0006, midleName, Environment.NewLine);
            }
            else if (!IsAlphaCharacter(midleName))
            {
                msg = string.Format(MsgResource.M0028, midleName, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// Validate date of birth string
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public string OrderDateOfBirthValidate(string dateOfBirth)
        {
            // PID.7.1-8 numberic - required
            string msg = string.Empty;
            const string dobRegex = @"^\d{8}$";
            if (!Regex.IsMatch(dateOfBirth, dobRegex))
            {
                msg = string.Format(MsgResource.M0012, Environment.NewLine);
            }
            return msg;
        }

        /// <summary>
        /// Patient Gender   
        /// Required 
        /// Use:  For Patient demographics, for Third Party Billing, and for certain test 
        /// procedures that require gender for calculation of result.  
        /// 'M' or '1' – Male 
        /// 'F' or '0' – Female 
        /// 'N' – Not Indicated 
        /// '1' and '0' are for backward compatibility only
        /// 
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public string OrderGenderValidate(string gender)
        {
            string msg = string.Empty;
            const string genderRegex = @"^[M|F|N|0|1]$";

            //PID.8.1 - 1 char
            if (gender.Length == 0)
            {
                msg = MsgResource.M0035;
            }
            else if (!Regex.IsMatch(gender, genderRegex))
            {
                msg = string.Format(MsgResource.M0007, gender, Environment.NewLine);
            }
            return msg;
        }

        /// <summary>
        ///  Patient Race  
        ///  Use:  Race is required for certain test procedures.  If maternal serum 
        ///  screening testing will be supported through the interface, this field is 
        ///  required. 
        ///  'A' – Asian  
        ///  'B' – Black or African American  
        ///  'C' –White / Caucasian  
        ///  'H' – Hispanic (for future use see PID-22 for Ethnicity) 
        ///  'I' – American Indian or Alaskan Native  
        ///  'O' – Other Race  
        ///  'X' – Race Not Indicated 
        ///  'J' – Ashkenazi Jewish (only for Integrated Genetics)  
        ///  'S' – Sephardic Jewish (only for Integrated Genetics) 
        ///  
        /// </summary>
        /// <param name="race"></param>
        /// <param name="isRequired"> </param>
        /// <returns></returns>
        public string OrderRaceValidate(string race, bool isRequired)
        {
            string msg = string.Empty;
            const string raceRegex = @"^[A|B|C|H|I|O|X|J|S]$";

            //PID.10 - 1 char
            if (race.Length == 0)
            {
                // Todo: clear required condtion for race(PID.10) here
                if (isRequired)
                {
                    msg = string.Format(MsgResource.M0011, Environment.NewLine);
                }
            }
            else if (!Regex.IsMatch(race, raceRegex))
            {
                msg = string.Format(MsgResource.M0008, race, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        ///  11.1   
        ///  Patient Address (Line 1) 
        ///  Use:    For  patient  demographic  purposes.    Required for  Patient  and  Third 
        ///  Party Billing and for Blood Lead Testing.   
        ///  Alpha, Numeric, or Special Characters 
        ///  
        /// </summary>
        /// <param name="patientAddress"></param>
        /// <returns></returns>
        public string OrderPatientAddressValidate(string patientAddress)
        {
            string msg = string.Empty;

            //PID,11,1 - 35 char
            if (patientAddress.Length == 0)
            {
                // Todo: cleare required condition for PID.11.1 here
            }
            else if (patientAddress.Length > AppointmentConstants.PID_11_1_LENGTH)
            {
                msg = string.Format(MsgResource.M0009, patientAddress, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// PID.11.3 
        /// Patient City   
        /// Use:    For  patient  demographic  purposes.    Required for  Patient  and  Third 
        /// Party Billing and for Blood Lead Testing. 
        /// LCA Length: 16 Alpha Characters  
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public string OrderCityValidate(string city)
        {
            string msg = string.Empty;

            //PID.11.3 - 16 chars
            if (city.Length == 0)
            {
                //Todo: clear required or not for PID.11.3 for lab order here
            }
            else
            {
                if (!IsAlphaCharacter(city))
                {
                    msg = string.Format(MsgResource.M0029, city, Environment.NewLine);
                }
                else if (city.Length > AppointmentConstants.PID_11_3_LENGTH)
                {
                    msg = string.Format(MsgResource.M0010, city, Environment.NewLine);
                }
            }

            return msg;
        }

        /// <summary>
        /// PID.11.4 
        /// Patient State or Province   
        /// Use: For patient demographic purposes.  Required for Patient and Third 
        /// Party Billing and for Blood Lead Testing. 
        /// Upper case state abbreviation 
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string OrderStateValidate(string state)
        {
            string msg = string.Empty;
            //const string stateReg = @"^A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY]$";
            const string stateReg = @"^(?-i:A[LKSZRAEP]|C[AOT]|D[EC]|F[LM]|G[AU]|HI|I[ADLN]|K[SY]|LA|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[ARW]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY])$";
            // PID.11.4 - 2 chars
            if (state.Length == 0)
            {
                // Todo: not clear required or not for PID.11.4 for lab order
            }
            else if (!Regex.IsMatch(state, stateReg))
            {
                msg = string.Format(MsgResource.M0030, state, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// PID.11.5 
        /// Patient Zip or Postal Code   
        /// Use: For patient demographic purposes.  Required for Patient and Third 
        /// Party Billing and for Blood Lead Testing. 
        /// LCA Length: 9 Numeric Characters 
        /// Note:  LabCorp accepts a 5-position or 9-position ZIP code.  Do not send dashes.
        /// </summary>
        /// <param name="patientZipCode"></param>
        /// <returns></returns>
        public string OrderPatientZipCodeValidate(string patientZipCode)
        {
            string msg = string.Empty;

            //PID.11.5 -5 or 9 numeric characters
            if (patientZipCode.Length == 0)
            {
                // Todo: not clear required condition PID.11.5
            }
            else if (!Regex.IsMatch(patientZipCode, @"^\d{5}$|^\d{9}$"))
            {
                msg = string.Format(MsgResource.M0013, patientZipCode, Environment.NewLine, Environment.NewLine);

                //if (PatientZipCode.Length > 9)
                //{
                //    msg = string.Format(MsgResource.M0012, PatientZipCode, Environment.NewLine);
                //}
            }

            return msg;
        }

        /// <summary>
        /// PID.13 Patient Home Phone Number   
        /// Use:  For patient demographic purposes.  Required for Patient and Third 
        /// Party Billing and for certain test procedures including Blood Lead Testing. 
        /// LCA Length: 10 Numeric Characters 
        /// </summary>
        /// <param name="PatientPhoneNumber"></param>
        /// <returns></returns>
        public string OrderPatientPhoneValidate(string PatientPhoneNumber)
        {
            string msg = string.Empty;
            string phoneRegex = @"^\d{0,10}$";
            //PID.13 - 10 chars
            if (PatientPhoneNumber.Length == 0)
            {
                //Todo: not clear required condition for PID.13 for oder message
            }
            else if (!Regex.IsMatch(PatientPhoneNumber, phoneRegex))
            {
                msg = string.Format(MsgResource.M0014, PatientPhoneNumber, Environment.NewLine);
            }
            return msg;
        }

        /// <summary>
        /// LabCorp Client ID# (Account Number) 
        /// Use:  For client identification purposes and for electronic data retrieval. 
        /// LCA Length: 8 Numeric Characters 
        /// Required.
        /// “LabCorp Client ID” is the client‟s eight-digit account number. The 
        /// client‟s Salesperson or Account Manager assigns this to the client 
        /// </summary>
        /// <param name="AccountNo"></param>
        /// <returns></returns>
        public string OrderAccountValidate(string AccountNo)
        {
            string msg = string.Empty;

            // PID.18.1 - 8 digrit numeric characters-Required
            if (!Regex.IsMatch(AccountNo, @"^\d{8}$"))
            {
                msg = string.Format(MsgResource.M0015, AccountNo, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// Validate input data for Fasting Flag (NTE.5.1)
        /// LCA Length: 1 Upper case Alpha character
        /// Required
        /// Allow: 'Y' or 'N'
        /// </summary>
        /// <param name="FastingFlag">fasting flag</param>
        /// <returns></returns>
        public string OrderFastingFlagValidate(string FastingFlag)
        {
            string msg = string.Empty;
            // NTE.5.1 - 1
            if (!Regex.IsMatch(FastingFlag, @"^[Y|N]{1}$"))
            {
                msg = string.Format(MsgResource.M0017, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// ORC.2.1
        /// Unique Foreign Accession or Specimen ID  
        /// Use:  Client specific accessioning or specimen identification number.  
        /// Required for some vendor setups.   
        /// LCA Length: 30 Alpha, Numeric, or Special Characters 
        /// The Unique Foreign Accession/Specimen Identification values in ORC-
        /// 2 and OBR-2 segments must match. 
        /// Todo: validate for ORC-2 match with OBR-2(not need because EDI Adapter put data from LabOrder.SpecmenId to both)
        /// </summary>
        /// <param name="SpecmenId"></param>
        /// <returns></returns>
        public string OrderSpecmenIdValidate(string SpecmenId)
        {
            string msg = string.Empty;
            //ORC.2.1 - 30 - required
            if (SpecmenId.Length == 0)
            {
                msg = string.Format(MsgResource.M0039, Environment.NewLine);
            }

            if (SpecmenId.Length > AppointmentConstants.ORC_2_1_LENGTH)
            {
                msg = string.Format(MsgResource.M0040, SpecmenId, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// 12.1 
        /// Ordering Provider ID Number   
        /// Use:  Identifies the Authorizing/Billing provider.  Used by certain vendor 
        /// systems for matching.   
        /// 
        /// LCA length: 10 Alpha, Numeric, or Special Characters 
        /// 
        /// Required condition: 
        /// Ordering Provider is required either in ORC or OBR.  ORC-12-ordering 
        /// provider is the same as OBR-16-ordering provider.  If the ordering 
        /// provider is not present in the ORC, it must be present in the associated 
        /// OBR.  (This rule is the same for other identical fields in the ORC and 
        /// OBR and promotes upward and ASTM compatibility.)  This is 
        /// particularly important when results are transmitted in an ORU 
        /// message.  In this case, the ORC is not required and the identifying filler 
        /// order number must be present in the OBR segments. 
        /// 
        /// Definition:  This field identifies the provider who is authorizing the 
        /// ordered test.  Both the Ordering Provider ID Number and the Ordering 
        /// Provider Name must be present.   
        /// NPI is required for all orders to identify the provider authorizing the test and/or authorizing the billing to a Third Party.
        /// </summary>
        /// <param name="OrderingProviderIdNumber">NPI number</param>
        /// <returns></returns>
        public string OrderOrderingProviderIdValidate(string OrderingProviderIdNumber)
        {
            string msg = string.Empty;
            //ORC.12.1 - 10
            if (OrderingProviderIdNumber.Length == 0) // Required for all order
            {
                msg = string.Format(MsgResource.M0038, Environment.NewLine);
            }
            else if (OrderingProviderIdNumber.Length > AppointmentConstants.ORC_12_1_LENGTH)
            {
                msg = string.Format(MsgResource.M0018, OrderingProviderIdNumber, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// Validate input data for ORC.12.2
        ///  Use: Physician/Provider identifier.  Required if not sent in OBR. 
        ///  LCA Length: 12 Alpha Characters 
        /// Alway required because EDI Adapter set same data for OBR.16.2, ORC.12.2.
        /// 
        ///  Currently 9 characters are used but it will expand to 25 characters in 
        ///  the future.   
        ///  Do not include Suffix or Degree  
        /// </summary>
        /// <param name="OrderingProviderLastName"></param>
        /// <returns></returns>
        public string OrderOrderingProviderLastNameValidate(string OrderingProviderLastName)
        {
            //ORC.12.2 - 25
            string msg = string.Empty;
            if (OrderingProviderLastName.Length == 0)
            {
                msg = string.Format(MsgResource.M0037, Environment.NewLine);
            }
            else if (!IsAlphaCharacter(OrderingProviderLastName))
            {
                msg = string.Format(MsgResource.M0041, OrderingProviderLastName, Environment.NewLine);
            }
            else if (OrderingProviderLastName.Length > AppointmentConstants.ORC_12_2_LENGTH)
            {
                msg = string.Format(MsgResource.M0019, OrderingProviderLastName, Environment.NewLine);
            }
            return msg;
        }

        /// <summary>
        /// validate input data for ORC.12.3 Ordering Provider First Initial 
        /// LCA length: 15 Alpha Characters 
        /// Physician/Provider identifier.  Required if ORC-12.2 is sent.   
        /// </summary>
        /// <param name="OrderingProviderFirstInitial">ORC.12.3</param>
        /// <param name="OrderingProviderLastName">ORC.12.2 </param>
        /// <returns></returns>
        public string OrderOrderingProviderFirstInitialValidate(string OrderingProviderFirstInitial, string OrderingProviderLastName)
        {
            string msg = string.Empty;

            //ORC.12.3 - 15
            if (OrderingProviderFirstInitial.Length == 0)
            {
                if (OrderingProviderLastName.Length != 0)
                {
                    msg = string.Format(MsgResource.M0036, Environment.NewLine);
                }
            }
            else if (!IsAlphaCharacter(OrderingProviderFirstInitial))
            {
                msg = string.Format(MsgResource.M0042, OrderingProviderFirstInitial, Environment.NewLine);
            }
            else if (OrderingProviderFirstInitial.Length > AppointmentConstants.ORC_12_3_LENGTH)
            {
                msg = string.Format(MsgResource.M0020, OrderingProviderFirstInitial, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// Validate number of selected product for an Lab Order message.
        /// At this time, only 40 orders are supported. Any more OBR added will be ignored.
        /// Required at least 1 product selected
        /// </summary>
        /// <param name="numberOfProduct">Number of selected products for lab order</param>
        /// <returns></returns>
        public string OrderProductCountValidate(int numberOfProduct)
        {
            string msg = string.Empty;

            // At this time, only 40 orders are supported. Any more OBR added will be ignored.
            if (numberOfProduct > AppointmentConstants.MAX_NUMBER_OF_PRODUCTS)
            {
                msg = string.Format(MsgResource.M0021, numberOfProduct, Environment.NewLine);
            }
            else if (numberOfProduct == 0)
            {
                msg = string.Format(MsgResource.M0043, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// validate input data for OBR-13.1
        /// LCA Length: 64 Alpha, Numeric, or Special 
        /// </summary>
        /// <param name="RelevantClinicalInformation"></param>
        /// <returns></returns>
        public string OrderRelevantClinicalValidate(string RelevantClinicalInformation)
        {
            string msg = string.Empty;
            // OBR.13.1 - 64
            if (RelevantClinicalInformation.Length > AppointmentConstants.OBR_13_1_LENGTH)
            {
                msg = string.Format(MsgResource.M0022, Environment.NewLine);
            }

            return msg;
        }

        /// <summary>
        /// To validate for OBR.4.1.
        /// Maxlength 15 Alpha, Numeric, or Special Characters 
        /// Required
        /// </summary>
        /// <param name="LabCorpOrderCode"></param>
        /// <param name="productListIndex"></param>
        /// <returns></returns>
        public string OrderLabCorpOrderCodeValidate(string LabCorpOrderCode, int productListIndex)
        {
            string msg = string.Empty;
            // OBR.4.1 - 15 alpha, numeric or special characters - required
            if (LabCorpOrderCode.Length == 0)
            {
                msg = string.Format(MsgResource.M0016, productListIndex, Environment.NewLine);
            }
            else if (LabCorpOrderCode.Length > AppointmentConstants.OBR_4_1_LENGTH)
            {
                msg = string.Format(MsgResource.M0024, productListIndex,
                    LabCorpOrderCode, Environment.NewLine);
            }
            return msg;
        }

        /// <summary>
        /// Validate Required, Length for OBR.4.2
        /// </summary>
        /// <param name="TestOrderName">LabCorp Test Order Name</param>
        /// <param name="productListIndex">Index of checking product in product list of order</param>
        /// <returns>error message if not valid.
        /// Empty string if valid.</returns>
        public string OrderTestOrderNameValidate(string TestOrderName, int productListIndex)
        {
            string msg = string.Empty;

            // OBR.4.2 - 50 Alpha, Numeric, or Special Characters - Required
            if (TestOrderName.Length == 0)
            {
                msg = string.Format(MsgResource.M0031, productListIndex, Environment.NewLine);
            }
            else if (TestOrderName.Length > AppointmentConstants.OBR_4_2_LENGTH)
            {
                msg = string.Format(MsgResource.M0025, TestOrderName, Environment.NewLine);
            }

            return msg;
        }

        #endregion Validate Lab Order information
 
    }
}