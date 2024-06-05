
namespace SolomonInvoice
{
    public class CONST
    {
        public const string  maxRow = "MAX_RECORD";
        public const string _PARTITION_FORMAT = "TyyyyMM";
        public const string _DATETIME_FORMAT = "dd/MM/yyyy HH:mm:ss";
        public const string _DATE_FORMAT = "dd/MM/yyyy";
        public const string _DATE_FORMAT_ddMMyyyy = "ddMMyyyy";
        public const string _DATE_EXP_FORMAT_yyyyMMdd = "yyyyMMdd";
        public const string _TIME_FORMAT_HHmmss = "HHmmss";
        public const string _EXPORT_TRANX_HOUR = "EXP_TRANX_HOUR";
        public const string _WAREHOUSE = "WAREHOUSE";
        public const string _WAREHOUSE_MODUL_DB_CONN = "DB_CONN";

        public const string _EXPORT_CMS_HOUR = "EXP_CMS_HOUR";
        public const string _EXPORT_CMS_SERVICES = "EXP_CMS_SERVICES";
        public const string _CMS_MAIL_LIST = "CMS_MAIL";
        public const string _ERR_SEND_TO_ADDR = "ERR_SEND_TO";
        public const string _ERR_CC_ADDR = "ERR_CC";
        public const string _ERR_SUBJECT = "ERR_SUBJECT";
        public const string _TRX_SEND_TO_ADDR = "TRX_SEND_TO";
        public const string _TRX_CC_ADDR = "TRX_CC";
        public const string _TRX_SUBJECT = "TRX_SUBJECT";
        public const string _EVT_SEND_TO_ADDR = "EVT_SEND_TO";
        public const string _EVT_CC_ADDR = "EVT_CC";
        public const string _EVT_SUBJECT_ADDR = "EVT_SUBJECT";
        
        public const string _DOT_TXT = ".txt";
        public const string _DOT_XLS = ".xls";
        public const string _MODULE_CODE_DATA = "DATA";
        public const string _MODULE_CODE_REPORT = "REPORT";
        public const string _BATCH_FILE_LOCATION = "BATCH_FILE_LOCAL";
        public const string _CONNECTION_STRING = "QUERY_CONN";
        public const string _BF_TXT_HEADER = "ONLINE.PAYMENT";
        public const string _BF_SERVICE_USER = "SERVICE_EXEC_USR";
        public const string _BF_SERVICE_PWD = "SERVICE_EXEC_PWD";
        public const string _BF_SERVICE_GROUP = "BF_SERVICE";
        public const string _BF_SERVICE_ACNT_TYPE = "SERVICE_ACNT_TYPE";
        public const string _BF_SERVICE_LOCAL_SYSTEM = "LocalSystem";
        public const string _BF_SERVICE_LOCAL_SERVICE = "LocalService";
        public const string _BF_SERVICE_LOCAL_USER = "User";
        public const string _BF_SERVICE_EXP_GROUP = "BF_SERVICE_EXPORT";
        public const string _BF_EXP_FILE_SERVICE = "BF_EXP_FILE";
        public const string _BF_EXP_CMS_SERVICE = "BF_EXP_CMS";
        public const string _BF_EXP_EVT_LOG_SERVICE = "BF_EXP_EVT_LOG";

        /** PHONG add 20-JAN-2010 */
        public const string _POSTED_STATUS = "P";

        /** PHONG add 14-DEC-2009 */
        public const int _EXPORT_BVL_TYPE = 1;
        public const int _EXPORT_DEFAULT_TYPE = 0;


        public const int _EXPORT_DEFAULT_FORMAT = 0;
        public const int _EXPORT_BVL_FORMAT = 1; // may be apply for follow provider acnt
        public const int _EXPORT_PRU_FORMAT = 2;
        public const int _EXPORT_AIA_FORMAT = 3;//Son add 23-Feb-2010
        public const int _EXPORT_DAICHI_FORMAT = 4;
        public const int _EXPORT_EVN_FORMAT = 5;
        public const int _EXPORT_PPF_FORMAT = 6;
        public const int _EXPORT_HSBC_FORMAT = 7;
        public const int _EXPORT_VMS_FORMAT =8;
        public const int _EXPORT_MB_FORMAT = 9; // add MB_Fomater
        public const int _EXPORT_MB2_FORMAT = 10;

        /** PHONG add 17-DEC-2009*/
        public const string _SERVICE_IS_CHOSEN = "1";
        public const string _SERVICE_IS_NOT_CHOSEN = "0";

        public const int _INSURANCE_GROUP_ID = 1;
        public const int _INTERNET_GROUP_ID = 2;
        public const int _TELECOM_GROUP_ID = 3;
        public const int _BANK_GROUP_ID = 4;
        public const int _AIR_GROUP_ID = 5;
        public const int _SCHOOL_GROUP_ID = 6;
        public const int _FINANCIAL_GROUP_ID = 7;
        public const int _PAY_GROUP_ID = 200;

        /** PHONG add 17-DEC-2009*/

        /** PHONG add 24-JAN-2010 */
        public const int _AMENDED_TRANSACTION_CATEGORY = 2;
        public const int _CANCELLED_TRANSACTION_CATEGORY = 6;

        public const int _IS_RE_EXPORTED_MODE = 1;
        public const int _IS_SERVICE_MODE = 0;

        /** PHONG add 7-MAR-2010 */
        public const int _GET_EOD_TRANX = 0;
        public const int _GET_CUT_OF_TIME_TRANX = 1;
        /** end of PHONG add 7-MAR-2010 */

        public const string _BVL_PAYMENT_MODE_APPEND = "A";
        public const string _BVL_PAYMENT_MODE_INCREASE = "I";
        public const string _BVL_PAYMENT_MODE_DECREASE = "D";
        public const string _BVL_PAYMENT_MODE_CANCEL = "C";
        public const int _BVL_PROVIDER_ACNT_ID = 1450;
        public const int _HSBC_PROVIDER_ACNT_ID = 1530;

        public const string _PARTNER_ACCOUNT_NUMBER_PREFIX = "8080";
        public const char _SPLIT_CHARACTER = '#';
        /** end of PHONG add 24-JAN-2010 */

        /** Son  add 22-FEB-2010 */
        public const string _EXPORT_DAY_BY_DAY_FILES = "A";
        public const string _EXPORT_GENERAL_FILE = "O";
        public const string _EXPORT_MODE_PARAM = "EXP_MODE";
        /**End Son  add 22-FEB-2010 */


        public const string _PAYMENT_MODE_APPEND = "A";
        public const string _PAYMENT_MODE_INCREASE = "I";
        public const string _PAYMENT_MODE_DECREASE = "D";
        public const string _PAYMENT_MODE_CANCEL = "C";
        public const string _BVL_CODE_FTP = "000004";//SOn ADD 27-2-2010 


        public const string _HEADER_VMS = "ServiceCode,SettlementDate,TransID,ProcessCode,TransDatetime,ISDN,CenterCode,CustBankCode,CustBankAccNum,VMSBankCode,VMSBankAccNum,TransAmount,ResponseCode";

    }



}
