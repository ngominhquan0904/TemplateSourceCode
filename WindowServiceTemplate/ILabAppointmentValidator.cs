namespace WindowServiceTemplate
{
    public interface ILabAppointmentValidator
    {
        /// <summary>
        /// Validate MSH.4 Sending facility input data
        /// </summary>
        /// <param name="sendingFacility">input data</param>
        /// <returns>
        /// Empty string when input data is validate. 
        /// Error message when input data is invalidate</returns>
        string OrderSendingFacilityValidate(string sendingFacility);

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
        string OrderExternalPatientIdValidate(string ExternalPatientId);

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
        string OrderAltPatientIdValidate(string alternatePatientId);

        /// <summary>
        /// PID.5.1 
        /// Patient Last Name 
        /// Use:  Patient identifier 
        /// LCA Length: 25 Alpha Characters 
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        string OrderLastNameValidate(string lastName);

        /// <summary>
        /// PID.5.2 
        /// Patient First Name 
        /// Use:  Patient identifier 
        /// LCA Length: max 15 Alpha Characters 
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        string OrderFirstNameValidate(string firstName);

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
        string OrderMidleNameValidate(string midleName);

        /// <summary>
        /// Validate date of birth string
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        string OrderDateOfBirthValidate(string dateOfBirth);

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
        string OrderGenderValidate(string gender);

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
        string OrderRaceValidate(string race, bool isRequired);

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
        string OrderPatientAddressValidate(string patientAddress);

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
        string OrderCityValidate(string city);

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
        string OrderStateValidate(string state);

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
        string OrderPatientZipCodeValidate(string patientZipCode);

        /// <summary>
        /// PID.13 Patient Home Phone Number   
        /// Use:  For patient demographic purposes.  Required for Patient and Third 
        /// Party Billing and for certain test procedures including Blood Lead Testing. 
        /// LCA Length: 10 Numeric Characters 
        /// </summary>
        /// <param name="PatientPhoneNumber"></param>
        /// <returns></returns>
        string OrderPatientPhoneValidate(string PatientPhoneNumber);

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
        string OrderAccountValidate(string AccountNo);

        /// <summary>
        /// Validate input data for Fasting Flag (NTE.5.1)
        /// LCA Length: 1 Upper case Alpha character
        /// Required
        /// Allow: 'Y' or 'N'
        /// </summary>
        /// <param name="FastingFlag">fasting flag</param>
        /// <returns></returns>
        string OrderFastingFlagValidate(string FastingFlag);

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
        string OrderSpecmenIdValidate(string SpecmenId);

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
        string OrderOrderingProviderIdValidate(string OrderingProviderIdNumber);

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
        string OrderOrderingProviderLastNameValidate(string OrderingProviderLastName);

        /// <summary>
        /// validate input data for ORC.12.3 Ordering Provider First Initial 
        /// LCA length: 15 Alpha Characters 
        /// Physician/Provider identifier.  Required if ORC-12.2 is sent.   
        /// </summary>
        /// <param name="OrderingProviderFirstInitial">ORC.12.3</param>
        /// <param name="OrderingProviderLastName">ORC.12.2 </param>
        /// <returns></returns>
        string OrderOrderingProviderFirstInitialValidate(string OrderingProviderFirstInitial, string OrderingProviderLastName);

        /// <summary>
        /// Validate number of selected product for an Lab Order message.
        /// At this time, only 40 orders are supported. Any more OBR added will be ignored.
        /// Required at least 1 product selected
        /// </summary>
        /// <param name="numberOfProduct">Number of selected products for lab order</param>
        /// <returns></returns>
        string OrderProductCountValidate(int numberOfProduct);

        /// <summary>
        /// validate input data for OBR-13.1
        /// LCA Length: 64 Alpha, Numeric, or Special 
        /// </summary>
        /// <param name="RelevantClinicalInformation"></param>
        /// <returns></returns>
        string OrderRelevantClinicalValidate(string RelevantClinicalInformation);

        /// <summary>
        /// To validate for OBR.4.1.
        /// Maxlength 15 Alpha, Numeric, or Special Characters 
        /// Required
        /// </summary>
        /// <param name="LabCorpOrderCode"></param>
        /// <param name="productListIndex"></param>
        /// <returns></returns>
        string OrderLabCorpOrderCodeValidate(string LabCorpOrderCode, int productListIndex);

        /// <summary>
        /// Validate Required, Length for OBR.4.2
        /// </summary>
        /// <param name="TestOrderName">LabCorp Test Order Name</param>
        /// <param name="productListIndex">Index of checking product in product list of order</param>
        /// <returns>error message if not valid.
        /// Empty string if valid.</returns>
        string OrderTestOrderNameValidate(string TestOrderName, int productListIndex);
 
    }
}