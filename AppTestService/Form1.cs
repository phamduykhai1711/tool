using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
//using AutoUpdaterDotNET;
using System.Net;
//using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using RestSharp;
using Newtonsoft.Json;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Dynamic;

//using System.Net.Http.WinHttpHandler;
//using Aspose.Cells;
//using Spire.Xls;

namespace SolomonInvoice
{
    public partial class Form1 : Form
    {
        public const string default_field_extend = "Exp: PARTNER-EMAIL, CONTRACT-REF";

        //Contructor
        public Form1()
        {
            InitializeComponent();
            this.field_extend.Text = default_field_extend;
            var dtSource = new List<object>();
            dtSource.Add(new
            {
                id = "0",
                name = "--- Lấy tất cả ---"
            });
            dtSource.Add(new
            {
                id = "1",
                name = "Lấy tài liệu 2 bên đã ký"
            });
            dtSource.Add(new
            {
                id = "2",
                name = "Lấy tài liệu đơn vị đã ký"
            });
            dtSource.Add(new
            {
                id = "3",
                name = "Lấy tài liệu Partner đã ký"
            });
            this.hinhthuc.DataSource = dtSource;

            var dtMenuChucnang = new List<object>();
            dtMenuChucnang.Add(new
            {
                id = "1",
                name = "Download Tài liệu"
            });
            dtMenuChucnang.Add(new
            {
                id = "2",
                name = "Export Excel"
            });
            this.menu_chucnang.DataSource = dtMenuChucnang;
        }
        //com.cmcsoft.demohoadon.siv_v_ph_hoadon hoadon = new com.cmcsoft.demohoadon.siv_v_ph_hoadon();

        private static string b_url_list = "";
        private static string b_url_contract = "";
        private static string b_url_attack = "";
        private static string b_url_bangchung = "";
        private static string b_url_getCompany = "";
        private static string b_url_getDepartment = "";
        private static string b_ma_dvi = "";
        private static string b_api_key = "";

        private static string b_api_get_attach_file_id = "";
        private static string b_api_get_contract_file = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            //Check update
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            //AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            string version = fvi.FileVersion;
            lblphienban.Text = "Ver: " + version;
            //AutoUpdater.DownloadPath = "update";
            //AutoUpdater.Start("http://bot.giaodichbds.info/update.xml");

            string pathHoadon = Directory.GetCurrentDirectory() + @"\caidat.xml";

            XmlDocument xdcHoadon = new XmlDocument();
            //Lấy thông tin từ file xml.
            xdcHoadon.Load(pathHoadon);
            XmlNodeList xnlNodesHoadon = xdcHoadon.SelectNodes("caidat");
            madonvi.Text = Convert.ToString(xnlNodesHoadon[0]["madonvi"].InnerText);
            log.Text = Convert.ToString(xnlNodesHoadon[0]["Log"].InnerText);
            apikey.Text = Convert.ToString(xnlNodesHoadon[0]["apikey"].InnerText);
            thumuc.Text = Convert.ToString(xnlNodesHoadon[0]["thumuc"].InnerText);

            // Khai báo một thể hiện của lớp DirectoryInfo
            DirectoryInfo directory_log = new DirectoryInfo(log.Text);

            // Kiểm tra thư mục chưa tồn tại mới sử dụng phương thức tạo
            if (!directory_log.Exists)
            {
                // Sử dụng phương thức Create để tạo thư mục.
                directory_log.Create();
                LogController.LogBatchFileProcess("khởi tạo thư mục thành công:" + log.Text, log.Text);
                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "-khởi tạo thư mục thành công:" + log.Text;
            }

            // Khai báo một thể hiện của lớp DirectoryInfo
            DirectoryInfo directory = new DirectoryInfo(thumuc.Text);

            // Kiểm tra thư mục chưa tồn tại mới sử dụng phương thức tạo
            if (!directory.Exists)
            {
                // Sử dụng phương thức Create để tạo thư mục.
                directory.Create();
                LogController.LogBatchFileProcess("khởi tạo thư mục thành công:" + thumuc.Text, log.Text);
                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "-khởi tạo thư mục thành công:" + thumuc.Text;
            }

            b_ma_dvi = madonvi.Text;
            b_api_key = apikey.Text;

            b_url_list = "https://api.econtract.cmcts.vn/contract/list?APIKey=" + apikey.Text + "&AccessCode=" + madonvi.Text;
            b_url_contract = "https://api.econtract.cmcts.vn/contract/info?APIKey=" + apikey.Text + "&AccessCode=" + madonvi.Text + "&id=";
            b_url_attack = "https://api.econtract.cmcts.vn/contract/attachfileinfo?APIKey=" + apikey.Text + "&AccessCode=" + madonvi.Text + "&id=";
            b_url_bangchung = "https://api.econtract.cmcts.vn/contract/proof?APIKey=" + apikey.Text + "&AccessCode=" + madonvi.Text + "&DocumentId=";
            b_url_getCompany = "https://api.econtract.cmcts.vn/company/list?APIKey=" + apikey.Text + "&AccessCode=" + madonvi.Text;

            b_api_get_attach_file_id = "https://api.econtract.cmcts.vn/contract/attach/info?accesscode=" + madonvi.Text + "&apikey=" + apikey.Text + "&id=";
            b_api_get_contract_file = "https://api.econtract.cmcts.vn/contract/attach/info/base64?accesscode=" + madonvi.Text + "&apikey=" + apikey.Text + "&documentid=";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LogController.LogBatchFileProcess("*********Bắt đầu tiến trình *********", log.Text);
            P_GET_HOPDONG();
            LogController.LogBatchFileProcess("*********Kết thúc tiến trình *********", log.Text);
        }

        //private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        //{
        //    if (args.IsUpdateAvailable)
        //    {
        //        try
        //        {
        //            if (AutoUpdater.DownloadUpdate(args))
        //            {
        //                Application.Exit();
        //            }
        //        }
        //        catch (Exception exception)
        //        {
        //            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void btn_start_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan startTime = new TimeSpan(22, 0, 0); // 10 giờ tối
            TimeSpan endTime = new TimeSpan(4, 0, 0);    // 4 giờ sáng
            TimeSpan currentTime = now.TimeOfDay;

            //if ((currentTime >= startTime && currentTime <= TimeSpan.FromHours(24)) ||
            //    (currentTime >= TimeSpan.Zero && currentTime <= endTime))
            //{
            //    LogController.LogBatchFileProcess("*********Hoàn tất khởi động công cụ đồng bộ************", log.Text);
            //    //txtResult.Text += "*********Hoàn tất khởi động công cụ đồng bộ************\r\n";
            //    LogController.LogBatchFileProcess("*********Bắt đầu tiến trình *********", log.Text);

            //    P_GET_HOPDONG();

            //    LogController.LogBatchFileProcess("*********Kết thúc tiến trình *********", log.Text);
            //    if (hengio.Value > 0)
            //    {
            //        timer1.Interval = Convert.ToInt32(hengio.Value) * 60000 * 60 * 24;
            //        timer1.Enabled = true;
            //        menu_chucnang.Enabled = false;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Chỉ được phép bắt đầu vào khoảng thời gian từ 22h đến 4h! Trân trọng");
            //}

            LogController.LogBatchFileProcess("*********Hoàn tất khởi động công cụ đồng bộ************", log.Text);
            //txtResult.Text += "*********Hoàn tất khởi động công cụ đồng bộ************\r\n";
            LogController.LogBatchFileProcess("*********Bắt đầu tiến trình *********", log.Text);

            P_GET_HOPDONG();

            LogController.LogBatchFileProcess("*********Kết thúc tiến trình *********", log.Text);
            if (hengio.Value > 0)
            {
                timer1.Interval = Convert.ToInt32(hengio.Value) * 60000 * 60 * 24;
                timer1.Enabled = true;
                menu_chucnang.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            menu_chucnang.Enabled = true;
            LogController.LogBatchFileProcess("*********Hoàn tất dừng công cụ đồng bộ************", log.Text);
            txtResult.Text += "*********Hoàn tất dừng công cụ đồng bộ************\r\n";
        }

        public string b_time_get = "";
        public string b_status = "";

        public void P_GET_HOPDONG()
        {
            try
            {
                int pageNumber = 1;
                if (int.TryParse(txtPageNumber.Text.ToString(), out pageNumber))
                {
                    if (pageNumber < 1)
                    {
                        MessageBox.Show("Số trang hóa phải bắt đầu từ 1");
                        txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Kết thúc do xảy ra lỗi --\r\n";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Số trang hóa đơn để trống hoặc sai định dạng");
                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Kết thúc do xảy ra lỗi --\r\n";
                    return;
                }
                DateTime FromDate = this.date_From.Value.Date, toDate = this.date_To.Value.Date;
                var kq = DateTime.Compare(FromDate, toDate);
                if (DateTime.Compare(FromDate, toDate) > 0)
                {
                    MessageBox.Show("Lỗi nhập Thời gian bắt đầu lớn hơn Thời gian kết thúc.");
                    return;
                }
                // Ẩn lặp lại theo ngày
                //if (this.chBox_Timer.Checked)
                //{
                //    if (hengio.Value <= 0)
                //    {
                //        MessageBox.Show("Số ngày lặp lại phải lớn hơn 0 ");
                //        return;
                //    }
                //    else
                //    {
                //        FromDate = DateTime.Now.Date;
                //        toDate = DateTime.Now.Date;
                //    }
                //}
                bool _isExportExcel = menu_chucnang.SelectedValue.ToString() == "2" ? true : false;
                bool _isAllowOverwrite = allow_overwrite.Checked;

                var client = new RestClient(b_url_list);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;
                request.AddHeader("Content-Type", "application/json");

                dynamic body = new ExpandoObject();
                body.CompanyId = ma_congty.SelectedValue ?? "";
                body.DepartmentId = ma_phongban.SelectedValue ?? "";
                body.SortType = "ASC";
                body.BothSigned = hinhthuc.SelectedValue.ToString() == "1" ? 1 : 0;
                body.PartnerSigned = hinhthuc.SelectedValue.ToString() == "2" ? 1 : 0;
                body.OfficeSigned = hinhthuc.SelectedValue.ToString() == "3" ? 1 : 0;
                body.FromDate = FromDate.ToString("dd/MM/yyyy");
                body.ToDate = toDate.ToString("dd/MM/yyyy");
                body.Segment = pageNumber - 1;
                body.PageSize = 100;

                if (_isExportExcel)
                {
                    body.PageSize = 100;
                }
                string[] _extraFields = null;

                var dTable_department = getAllApartmentCode();

                if (_isExportExcel)
                {
                    if (!string.IsNullOrWhiteSpace(field_extend.Text.ToString()) && field_extend.Text.ToString() != default_field_extend)
                    {
                        _extraFields = field_extend.Text.Split(',').Select(x => x.Trim()).Where(y => !string.IsNullOrEmpty(y)).ToArray();
                        body.ExtraFields = _extraFields;
                    }
                }

                var json_body = JsonConvert.SerializeObject(body);
                request.AddParameter("application/json", json_body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonString = response.Content;
                    var jsonObject = JObject.Parse(jsonString);
                    bool mess = (bool)jsonObject["Found"];
                    if (!mess)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu");
                        return;
                    }

                    var items = jsonObject["Items"];
                    var it = items.ToString(Newtonsoft.Json.Formatting.None);
                    if (_isExportExcel)
                    {
                        // export Excel
                        DataTable dtable = JsonStringToDataTable(items, _isExportExcel);
                        if (dtable.Rows.Count > 0)
                        {
                            var excelApp = new Microsoft.Office.Interop.Excel.Application();
                            Excel.Workbook workbook = excelApp.Workbooks.Add();

                            // Create a new worksheet
                            Excel.Worksheet workSheet = workbook.Sheets.Add();
                            workSheet.Name = "Contract";

                            string[] columnsToExport = { "DocumentId", "CompanyCode", "CompanyName", "Subject", "Note", "ContractTemplateName", "ContractTypeName", "WorkflowDefName", "FullName", "Address", "Mobile", "CreatedDate", "EffectedDate", "ExpiredDate", "KeyForCheck", "ContractNo" };
                            var total_columns = _extraFields == null ? columnsToExport : columnsToExport.Concat(_extraFields).ToArray();
                            //var total_columns = new string[columnsToExport.Length + col_ext.Length];
                            //columnsToExport.CopyTo(total_columns, 0);
                            //col_ext.CopyTo(total_columns, columnsToExport.Length);

                            // column headings
                            for (var col = 0; col < total_columns.Length; col++)
                            {
                                workSheet.Cells[1, col + 1] = total_columns[col];
                                // Bold column headings
                                Excel.Range headerRange = workSheet.Cells[1, col + 1];
                                headerRange.Font.Bold = true;
                                if(_extraFields != null && _extraFields.Contains(total_columns[col]))
                                {
                                    headerRange.Font.Color = ColorTranslator.ToOle(Color.FromArgb(186, 32, 32));
                                }

                                // Set cell values for the specified columns
                                for (var row = 0; row < dtable.Rows.Count; row++)
                                {
                                    string columnName = total_columns[col];
                                    int columnIndex = dtable.Columns.IndexOf(columnName);

                                    workSheet.Cells[row + 2, col + 1] = dtable.Rows[row][columnIndex];
                                }
                            }

                            // Auto-fit columns
                            workSheet.UsedRange.Columns.AutoFit();
                            // check file path
                            if (!string.IsNullOrEmpty(thumuc.Text))
                            {
                                try
                                {
                                    workbook.SaveAs(thumuc.Text + "/Contract_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
                                    workbook.Close();
                                    excelApp.Quit();

                                    LogController.LogBatchFileProcess(DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "-- Export excel thành công -- \\n", log.Text);
                                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "-- Export excel thành công -- \\n";
                                }
                                catch (Exception ex)
                                {
                                    LogController.LogBatchFileProcess(DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "-- Export excel LỖI -- " + ex.Message + "\\n", log.Text);
                                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "-- Export excel LỖI -- \\n" + ex.Message;
                                }
                            }
                            else
                            { // no file path is given
                                excelApp.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        // Download hợp đồng
                        DataTable b_dt = JsonStringToDataTable(items);
                        // kiêm tra danh sách thư mục chứa hợp đồng đã tải. loại bỏ lấy về nếu không cho ghi đè
                        string[] fileArray = Directory.GetFiles(thumuc.Text, "*.txt", SearchOption.AllDirectories);
                        if (!_isAllowOverwrite)
                        {
                            if (fileArray.Length > 0)
                            {
                                for (int b = 0; b < fileArray.Length; b++)
                                {
                                    string b_loai = fileArray[b].ToString();
                                    string b_id_luu = Path.GetFileName(b_loai).Replace(".txt", "");
                                    P_BO_HANG(ref b_dt, "DocumentID", b_id_luu);
                                }
                            }
                        }

                        // ghi lại số lượng file có thể lấy
                        LogController.LogBatchFileProcess("*********Số lượng hợp đồng có thể lấy:" + b_dt.Rows.Count + "************", log.Text);
                        //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "*********Số lượng hợp đồng có thể lấy:" + b_dt.Rows.Count + "************\r\n";
                        // Bắt đầu lấy file

                        if (b_dt.Rows.Count > 0)
                        {
                            int countt = 1;
                            for (int i = 0; i < b_dt.Rows.Count; i++)
                            {
                                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Đang tải xuống hóa đơn " + countt + "/" + b_dt.Rows.Count + " --\r\n";

                                countt++;

                                string b_congty = b_dt.Rows[i]["Companycode"].ToString();
                                string b_sohd = b_dt.Rows[i]["contractno"].ToString().Replace("\\", "-").Replace("/", "-");
                                string b_soid = b_dt.Rows[i]["DocumentID"].ToString();
                                string departmentId = b_dt.Rows[i]["frkAdDepartmentId"].ToString();
                                string departmentCode = "";
                                var dt_row = dTable_department.Select("DepartmentId = '" + departmentId + "'").FirstOrDefault(); 
                                if(dt_row != null)
                                {
                                     departmentCode = dt_row["DepartmentCode"].ToString();
                                }
                                try
                                {
                                    // kiểm tra thư mục
                                    // 1. Đường dẫn tới thư mục cần tạo New Directory
                                    string directoryPath = thumuc.Text + "\\" + b_congty;

                                    // 2.Khai báo một thể hiện của lớp DirectoryInfo
                                    DirectoryInfo directory = new DirectoryInfo(directoryPath);

                                    // Kiểm tra thư mục chưa tồn tại mới sử dụng phương thức tạo
                                    if (!directory.Exists)
                                    {
                                        // 3.Sử dụng phương thức Create để tạo thư mục.
                                        directory.Create();
                                        LogController.LogBatchFileProcess("khởi tạo thư mục đơn vị thành công:" + directoryPath, log.Text);
                                        //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "-khởi tạo thư mục đơn vị thành công:" + directoryPath + "\r\n";
                                    }

                                    // khởi tạo thư mục lưu hợp đồng
                                    if (!string.IsNullOrWhiteSpace(departmentCode))
                                    {
                                        directoryPath = directoryPath + "\\" + departmentCode;
                                        DirectoryInfo directory_depart = new DirectoryInfo(directoryPath);

                                        // Kiểm tra thư mục chưa tồn tại mới sử dụng phương thức tạo
                                        if (!directory_depart.Exists)
                                        {
                                            // 3.Sử dụng phương thức Create để tạo thư mục.
                                            directory_depart.Create();
                                            LogController.LogBatchFileProcess("khởi tạo thư mục Phòng ban thành công:" + directoryPath, log.Text);
                                            //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "-khởi tạo thư mục Phòng ban thành công:" + directoryPath + "\r\n";
                                        }
                                    }

                                    // vì nhiều hơn 1 file nên phải tạo cả thư mục
                                    // kiểm tra thư mục
                                    // 1. Đường dẫn tới thư mục cần tạo New Directory
                                    string directoryPath_hopdong = directoryPath + "\\" + b_sohd;

                                    // 2.Khai báo một thể hiện của lớp DirectoryInfo
                                    DirectoryInfo directory_hopdong = new DirectoryInfo(directoryPath_hopdong);

                                    // Kiểm tra thư mục chưa tồn tại mới sử dụng phương thức tạo
                                    if (!directory_hopdong.Exists)
                                    {
                                        // 3.Sử dụng phương thức Create để tạo thư mục.
                                        directory_hopdong.Create();
                                        LogController.LogBatchFileProcess("khởi tạo thư mục cho hợp đồng " + b_sohd + " thành công:" + directory_hopdong, log.Text);
                                        //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "khởi tạo thư mục cho hợp đồng " + b_sohd + " thành công:" + directory_hopdong + "\r\n";
                                    }
                                    // Trường hợp lấy theo số hợp đồng tại thời điểm tức thời


                                    //-------------------------------------------   HÀM MỚI   ----------------------------------------
                                    //lấy file dữ liệu hợp đồng
                                    string str_url_get_attach_file = b_api_get_attach_file_id + b_soid;

                                    var obj_attachFile = new RestClient(str_url_get_attach_file);
                                    obj_attachFile.Timeout = -1;
                                    var req_attachFile = new RestRequest(Method.GET);
                                    IRestResponse result_attachFile = obj_attachFile.Execute(req_attachFile);

                                    if (result_attachFile.StatusCode == System.Net.HttpStatusCode.OK)
                                    {
                                        string jsonString_contract = result_attachFile.Content;
                                        var jsonObject_contract = JObject.Parse(jsonString_contract);

                                        //Lấy id attachFile để call tiếp
                                        string attachFileId = "";
                                        JArray itemsArray = (JArray)jsonObject_contract["Items"];
                                        if (itemsArray.Count > 0)
                                        {
                                            JObject firstItem = (JObject)itemsArray[0];
                                            attachFileId = firstItem["AttachFileId"].ToString();
                                        }

                                        //====================   Call api lấy file doc   ===================
                                        string str_url_get_contract_file = b_api_get_contract_file + b_soid + "&attachfileid=" + attachFileId;
                                        var obj_contractFile = new RestClient(str_url_get_contract_file);
                                        obj_contractFile.Timeout = -1;

                                        var req_contractFile = new RestRequest(Method.GET);
                                        IRestResponse result_contractFile = obj_contractFile.Execute(req_contractFile);

                                        if (result_attachFile.StatusCode == System.Net.HttpStatusCode.OK)
                                        {
                                            string jsonString_contract_file = result_attachFile.Content;
                                            var jsonObject_contract_file = JObject.Parse(jsonString_contract_file);
                                            bool mess_contract = (bool)jsonObject_contract["Found"];
                                            if (mess_contract)
                                            {

                                                var items_contract = jsonObject_contract_file["Items"];
                                                DataTable b_dt2 = JsonStringToDataTable(items_contract);

                                                // kiểm tra đã có tài liệu chưa
                                                int b_tim_tenfile = Fi_TIM_COL(b_dt2, "AttachFileName");
                                                if (b_tim_tenfile >= 0)
                                                {
                                                    // lấy hợp đồng và các tài liệu kèm theo
                                                    if (b_dt2.Rows.Count > 0)
                                                    {
                                                        for (int j = 0; j < b_dt2.Rows.Count; j++)
                                                        {
                                                            string b_name = b_dt2.Rows[j]["AttachFileName"].ToString();
                                                            string b_main = b_dt2.Rows[j]["Main"].ToString();
                                                            string b_file_64 = b_dt2.Rows[j]["AttachContentBase64"].ToString();
                                                            if (b_file_64 != null && b_file_64 != "")
                                                            {
                                                                string b_duongdan = directory_hopdong + "\\" + b_name;
                                                                using (FileStream stream = new FileStream(b_duongdan, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                                                                {
                                                                    System.Byte[] byteArray = System.Convert.FromBase64String(b_file_64);
                                                                    stream.Write(byteArray, 0, byteArray.Length);
                                                                    LogController.LogBatchFileProcess("Lưu tài liệu thành công: " + b_name, log.Text);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                LogController.LogBatchFileProcess("Không tồn tại file " + b_name, log.Text);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            // lấy file bằng chứng
                                            if (bangchung.Checked == true)
                                            {
                                                string b_url_getbangchung = b_url_bangchung + b_soid;

                                                var client_bangchung = new RestClient(b_url_getbangchung);
                                                obj_contractFile.Timeout = -1;
                                                var request_bangchung = new RestRequest(Method.GET);

                                                IRestResponse response_bangchung = client_bangchung.Execute(request_bangchung);
                                                if (response_bangchung.StatusCode == System.Net.HttpStatusCode.OK)
                                                {

                                                    string jsonString_bangchung = response_bangchung.Content;
                                                    var jsonObject_bangchung = JObject.Parse(jsonString_bangchung);
                                                    bool mess_bangchung = (bool)jsonObject_bangchung["Found"];
                                                    if (mess_bangchung)
                                                    {
                                                        string b_file_bangchung64 = jsonObject_bangchung["ContentBase64"].ToString();
                                                        if (!string.IsNullOrEmpty(b_file_bangchung64))
                                                        {
                                                            string b_duongdan = directory_hopdong + "\\" + "bangchung.pdf";
                                                            using (System.IO.FileStream stream = new FileStream(b_duongdan, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                                                            {
                                                                System.Byte[] byteArray = System.Convert.FromBase64String(b_file_bangchung64);
                                                                stream.Write(byteArray, 0, byteArray.Length);
                                                                LogController.LogBatchFileProcess("Lưu bằng chứng thành công", log.Text);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            LogController.LogBatchFileProcess("Chưa hoàn thành chứng từ, hợp đồng không có file bằng chứng", log.Text);
                                                        }
                                                    }
                                                }
                                            }
                                            // lưu số id vào thư mục
                                            string b_duongdan_id = directory_hopdong + "\\" + b_soid + ".txt";
                                            using (StreamWriter sw = File.CreateText(b_duongdan_id))
                                            {
                                                sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
                                                sw.WriteLine("ID hop dong: {0}", b_soid);
                                                LogController.LogBatchFileProcess("Khởi tạo ID thành công, hoàn tất lưu hợp đồng số:" + b_congty + "-" + b_sohd, log.Text);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        LogController.LogBatchFileProcess("ERROR:Hợp đồng chưa có file dữ liệu: " + b_congty + "- " + b_sohd + " - " + b_soid, log.Text);
                                    }



                                    //-----------------------------------------   HÀM CŨ   ------------------------------------------
                                    //string b_url_get = b_url_contract + b_soid;

                                    //var client_contract = new RestClient(b_url_get);
                                    //client_contract.Timeout = -1;
                                    //var request_contract = new RestRequest(Method.GET);

                                    //IRestResponse response_contract = client_contract.Execute(request_contract);
                                    //if (response_contract.StatusCode == System.Net.HttpStatusCode.OK)
                                    //{
                                    //    string jsonString_contract = response_contract.Content;
                                    //    var jsonObject_contract = JObject.Parse(jsonString_contract);
                                    //    bool mess_contract = (bool)jsonObject_contract["Found"];
                                    //    if (mess_contract)
                                    //    {
                                    //        var items_contract = jsonObject_contract["Item"]["AttachFiles"];
                                    //        DataTable b_dt2 = JsonStringToDataTable(items_contract);

                                    //        // kiểm tra đã có tài liệu chưa
                                    //        int b_tim_tenfile = Fi_TIM_COL(b_dt2, "AttachFileName");
                                    //        if (b_tim_tenfile >= 0)
                                    //        {
                                    //            // lấy hợp đồng và các tài liệu kèm theo
                                    //            if (b_dt2.Rows.Count > 0)
                                    //            {
                                    //                for (int j = 0; j < b_dt2.Rows.Count; j++)
                                    //                {
                                    //                    string b_name = b_dt2.Rows[j]["AttachFileName"].ToString();
                                    //                    string b_main = b_dt2.Rows[j]["Main"].ToString();
                                    //                    string b_file_64 = b_dt2.Rows[j]["AttachContentBase64"].ToString();
                                    //                    //b_file_64 = b_file_64.Replace(",\"", "\"CMCTS\"");
                                    //                    //b_file_64 = b_file_64.Replace(",", "..");
                                    //                    //b_file_64 = b_file_64.Replace("\"CMCTS\"", ",\"");
                                    //                    if (b_file_64 != null && b_file_64 != "")
                                    //                    {
                                    //                        string b_duongdan = directory_hopdong + "\\" + b_name;
                                    //                        using (FileStream stream = new FileStream(b_duongdan, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                                    //                        {
                                    //                            System.Byte[] byteArray = System.Convert.FromBase64String(b_file_64);
                                    //                            stream.Write(byteArray, 0, byteArray.Length);
                                    //                            LogController.LogBatchFileProcess("Lưu tài liệu thành công: " + b_name, log.Text);
                                    //                            //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Lưu tài liệu thành công: " + b_name + "\r\n";
                                    //                        }
                                    //                    }
                                    //                    else
                                    //                    {
                                    //                        LogController.LogBatchFileProcess("Không tồn tại file " + b_name, log.Text);
                                    //                        //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Không tồn tại file " + b_name + "\r\n";
                                    //                    }
                                    //                }
                                    //            }
                                    //        }
                                    //    }

                                    //    //// lấy file đính kèm
                                    //    //string b_url_getattack = b_url_contract + b_soid;
                                    //    //var client_attack = new RestClient(b_url_getattack);
                                    //    //client_attack.Timeout = -1;
                                    //    //var request_attack = new RestRequest(Method.GET);

                                    //    //IRestResponse response_attack = client_attack.Execute(request_attack);
                                    //    //if (response_attack.StatusCode == System.Net.HttpStatusCode.OK)
                                    //    //{
                                    //    //    string b_goc_attack = response_attack.Content.Replace("\\", "");
                                    //    //    b_goc_attack = b_goc_attack.Substring(1, b_goc_attack.Length - 2);

                                    //    //    JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
                                    //    //    {
                                    //    //        NullValueHandling = NullValueHandling.Ignore,
                                    //    //        MissingMemberHandling = MissingMemberHandling.Ignore

                                    //    //    };
                                    //    //    var resultStr = JsonConvert.DeserializeObject<AttachResult>(b_goc_attack, serializerSettings);
                                    //    //    var att_list = new List<AttachFiles>();
                                    //    //    att_list = resultStr.Item.AttachFiles;

                                    //    //    foreach (var item in att_list)
                                    //    //    {
                                    //    //        var base64 = item.AttachContentBase64;
                                    //    //        var b_name_attack = item.AttachFileName;

                                    //    //        if (base64 != null && base64 != "")
                                    //    //        {
                                    //    //            string b_duongdan = directory_hopdong + "\\" + b_name_attack;
                                    //    //            using (System.IO.FileStream stream = System.IO.File.Create(b_duongdan))
                                    //    //            {
                                    //    //                System.Byte[] byteArray = System.Convert.FromBase64String(base64);
                                    //    //                stream.Write(byteArray, 0, byteArray.Length);
                                    //    //                LogController.LogBatchFileProcess("Lưu tài liệu đính kèm thành công: " + b_name_attack, log.Text);
                                    //    //                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Lưu tài liệu đính kèm thành công: " + b_name_attack;
                                    //    //            }
                                    //    //        }
                                    //    //        else
                                    //    //        {
                                    //    //            LogController.LogBatchFileProcess("Không tồn tại file đính kèm " + b_name_attack, log.Text);
                                    //    //            txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Không tồn tại file đính kèm " + b_name_attack;
                                    //    //        }

                                    //    //    }
                                    //    //}

                                    //    // lấy file bằng chứng
                                    //    if (bangchung.Checked == true)
                                    //    {
                                    //        string b_url_getbangchung = b_url_bangchung + b_soid;

                                    //        var client_bangchung = new RestClient(b_url_getbangchung);
                                    //        client_contract.Timeout = -1;
                                    //        var request_bangchung = new RestRequest(Method.GET);

                                    //        IRestResponse response_bangchung = client_bangchung.Execute(request_bangchung);
                                    //        if (response_bangchung.StatusCode == System.Net.HttpStatusCode.OK)
                                    //        {

                                    //            string jsonString_bangchung = response_bangchung.Content;
                                    //            var jsonObject_bangchung = JObject.Parse(jsonString_bangchung);
                                    //            bool mess_bangchung = (bool)jsonObject_bangchung["Found"];
                                    //            if (mess_bangchung)
                                    //            {
                                    //                string b_file_bangchung64 = jsonObject_bangchung["ContentBase64"].ToString();
                                    //                if (!string.IsNullOrEmpty(b_file_bangchung64))
                                    //                {
                                    //                    string b_duongdan = directory_hopdong + "\\" + "bangchung.pdf";
                                    //                    using (System.IO.FileStream stream = new FileStream(b_duongdan, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                                    //                    {
                                    //                        System.Byte[] byteArray = System.Convert.FromBase64String(b_file_bangchung64);
                                    //                        stream.Write(byteArray, 0, byteArray.Length);
                                    //                        LogController.LogBatchFileProcess("Lưu bằng chứng thành công", log.Text);
                                    //                        //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Lưu bằng chứng thành công\r\n";
                                    //                    }
                                    //                }
                                    //                else
                                    //                {
                                    //                    LogController.LogBatchFileProcess("Chưa hoàn thành chứng từ, hợp đồng không có file bằng chứng", log.Text);
                                    //                    //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Chưa hoàn thành chứng từ, hợp đồng không có file bằng chứng\r\n";
                                    //                }
                                    //            }
                                    //        }
                                    //    }
                                    //    // lưu số id vào thư mục
                                    //    string b_duongdan_id = directory_hopdong + "\\" + b_soid + ".txt";
                                    //    using (StreamWriter sw = File.CreateText(b_duongdan_id))
                                    //    {
                                    //        sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
                                    //        sw.WriteLine("ID hop dong: {0}", b_soid);
                                    //        LogController.LogBatchFileProcess("Khởi tạo ID thành công, hoàn tất lưu hợp đồng số:" + b_congty + "-" + b_sohd, log.Text);
                                    //        //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Khởi tạo ID thành công, hoàn tất lưu hợp đồng số:" + b_congty + " - " + b_sohd + "\r\n";
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    LogController.LogBatchFileProcess("ERROR:Hợp đồng chưa có file dữ liệu: " + b_congty + "- " + b_sohd + " - " + b_soid, log.Text);
                                    //    //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "ERROR:Hợp đồng chưa có file dữ liệu: " + b_congty + "- " + b_sohd + " - " + b_soid + "\r\n";
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    LogController.LogBatchFileProcess("ERROR: " + b_congty + "- " + b_sohd + " - " + b_soid + "\n" + ex.ToString(), log.Text);
                                    //txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "ERROR: " + b_congty + "- " + b_sohd + " - " + b_soid + "\n" + ex.ToString() + "\r\n";
                                }
                            }
                        }
                    }
                }
                else
                {
                    LogController.LogBatchFileProcess("ERROR: Kiểm tra lại mã đơn vị hoặc APIKey", log.Text);
                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- ERROR: Kiểm tra lại mã đơn vị hoặc APIKey\r\n";
                }
                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Hoàn thành tiến trình --\r\n";
            }
            catch (Exception ex)
            {
                LogController.LogBatchFileProcess("ERROR: " + ex.ToString(), log.Text);
                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- ERROR: " + ex.ToString() + "\r\n";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string[] fileArray = Directory.GetDirectories(thumuc.Text);
        }

        public DataTable JsonStringToDataTable(JToken items, bool is_exportExcel = false)
        {
            DataTable table = new DataTable();
            for (var i = 0; i < items.Count(); i++)
            {
                string jsonString = items[i].ToString(Newtonsoft.Json.Formatting.None);
                var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

                // Add columns to DataTable
                if (i == 0)
                {
                    foreach (var key in jsonObject.Keys)
                    {
                        table.Columns.Add(key, typeof(string));
                    }
                }

                // Add row to DataTable
                var row = table.NewRow();
                foreach (var key in jsonObject.Keys)
                {
                    if (is_exportExcel && key == "ExtraFields")
                    {
                        var exVal = jsonObject[key].ToString();
                        var exFields = JsonConvert.DeserializeObject<List<ExtraFields>>(exVal, new JsonSerializerSettings { NullValueHandling =NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore});
                        if (exFields.Count() > 0)
                        {
                            for (var j = 0; j < exFields.Count(); j++)
                            {                               
                                var field = exFields[j] == null ? "" : string.IsNullOrWhiteSpace(exFields[j].FieldName) ? "" : exFields[j].FieldName;
                                if(field != "")
                                {
                                    if (!table.Columns.Contains(field))
                                    {
                                        table.Columns.Add(field, typeof(string));
                                    }
                                    var val = exFields[j].FieldValue;
                                    row[field] = val == null ? "" : val;
                                }
                            }
                        }
                    }
                    else
                    {
                        row[key] = jsonObject[key] == null ? "" : jsonObject[key].ToString();
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable JsonStringToDataTable(string jsonString)
        {
            //jsonString = jsonString.Replace(",\"", "&&");
            //jsonString = jsonString.Replace(",", "-");
            //jsonString = jsonString.Replace("&&", ",\"");
            DataTable dt = new DataTable();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string jSA in jsonStringArray)
            {
                string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(ColumnsNameData) && ColumnsNameData != "''" && ColumnsNameData != "\u0022")
                        {
                            int idx = ColumnsNameData.IndexOf(":");
                            string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                            if (!ColumnsName.Contains(ColumnsNameString))
                            {
                                ColumnsName.Add(ColumnsNameString);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dt.Columns.Add(AddColumnName);
            }
            foreach (string jSA in jsonStringArray)
            {
                string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                        nr[RowColumns] = RowDataString;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;
        }

        public static void P_BO_HANG(ref DataTable b_dt, string b_ten, object b_gtri)
        {
            if (Fb_TRANG(b_dt)) return;
            int b_kt = b_dt.Rows.Count - 1;
            string b_s = OBJ_S(b_gtri).ToUpper();
            if (b_kt < 0) return;
            for (int i = b_kt; i > -1; i--)
                if (!(b_dt.Rows[i][b_ten] is DBNull) && OBJ_S(b_dt.Rows[i][b_ten]).ToUpper() == b_s) b_dt.Rows.RemoveAt(i);
            b_dt.AcceptChanges();
        }

        public static string OBJ_S(object b_obj)
        {
            return (b_obj == null) ? "" : C_NVL(b_obj.ToString());
        }
        public static string C_NVL(string b_in)
        { // Dan
            string b_kq = (b_in == null) ? "" : b_in.Trim();
            if (b_kq.ToUpper() == "NULL") b_kq = "";
            return b_kq;
        }

        public static bool Fb_TRANG(DataTable b_dt)
        {
            if (b_dt != null)
                if (b_dt.Rows.Count != 0) return false;
            return true;
        }

        public static void P_THEM_COL(ref DataTable b_dt, string b_truong, string b_gtri)
        {
            b_dt.Columns.Add(b_truong, b_gtri.GetType());
            for (int i = 0; i < b_dt.Rows.Count; i++) b_dt.Rows[i][b_truong] = b_gtri;
            b_dt.AcceptChanges();
        }

        public static int Fi_TIM_COL(DataTable b_dt, string b_ten)
        {
            if (b_dt == null) return -1;
            b_ten = b_ten.ToUpper();
            for (int i = 0; i < b_dt.Columns.Count; i++)
            {
                if (b_dt.Columns[i].ColumnName.ToUpper() == b_ten) return i;
            }
            return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Đường dẫn tới thư mục cần tạo New Directory
                string directoryPath_hopdong = thumuc.Text + "\\" + id.Text;

                // 2.Khai báo một thể hiện của lớp DirectoryInfo
                DirectoryInfo directory_hopdong = new DirectoryInfo(directoryPath_hopdong);

                // Kiểm tra thư mục chưa tồn tại mới sử dụng phương thức tạo
                if (!directory_hopdong.Exists)
                {
                    // 3.Sử dụng phương thức Create để tạo thư mục.
                    directory_hopdong.Create();
                    LogController.LogBatchFileProcess("khởi tạo thư mục cho hợp đồng " + id.Text + " thành công:" + directory_hopdong, log.Text);
                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "khởi tạo thư mục cho hợp đồng " + id.Text + " thành công:" + directory_hopdong + "\r\n";
                }
                //lấy file dữ liệu hợp đồng
                string b_url_get = b_url_contract + id.Text;

                var client_contract = new RestClient(b_url_get);
                client_contract.Timeout = -1;
                var request_contract = new RestRequest(Method.GET);

                IRestResponse response_contract = client_contract.Execute(request_contract);
                if (response_contract.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string b_goc2 = response_contract.Content.Replace("\\", "");
                    b_goc2 = b_goc2.Replace(",\"", "\"CMCTS\"");
                    b_goc2 = b_goc2.Replace(",", "..");
                    b_goc2 = b_goc2.Replace("\"CMCTS\"", ",\"");
                    DataTable b_dt2 = JsonStringToDataTable(b_goc2);

                    // kiểm tra đã có tài liệu chưa
                    int b_tim_tenfile = Fi_TIM_COL(b_dt2, "ContractNo");
                    int b_dulieufile = Fi_TIM_COL(b_dt2, "AttachFiles");
                    if (b_tim_tenfile >= 0 && b_dulieufile >= 0)
                    {
                        if (b_dt2.Rows.Count > 0)
                        {
                            for (int j = 0; j < b_dt2.Rows.Count; j++)
                            {
                                string b_name = b_dt2.Rows[j]["ContractNo"].ToString();
                                b_name = b_name.Replace("\\", "-");
                                b_name = b_name.Replace("/", "-");
                                string b_main = b_dt2.Rows[j]["Main"].ToString();
                                string b_file_64 = b_dt2.Rows[j]["AttachFiles"].ToString().Replace("AttachContentBase64:", "");
                                b_file_64 = b_file_64.Replace(",\"", "\"CMCTS\"");
                                b_file_64 = b_file_64.Replace(",", "..");
                                b_file_64 = b_file_64.Replace("\"CMCTS\"", ",\"");
                                if (b_file_64 != null && b_file_64 != "")
                                {
                                    string b_duongdan = directory_hopdong + "\\" + b_name + ".pdf";
                                    using (System.IO.FileStream stream = System.IO.File.Create(b_duongdan))
                                    {
                                        System.Byte[] byteArray = System.Convert.FromBase64String(b_file_64);
                                        stream.Write(byteArray, 0, byteArray.Length);
                                        LogController.LogBatchFileProcess("Lưu tài liệu thành công: " + b_name, log.Text);
                                        txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Lưu tài liệu thành công: " + b_name + "\r\n";
                                    }
                                }
                                else
                                {
                                    LogController.LogBatchFileProcess("Không tồn tại file " + b_name, log.Text);
                                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Không tồn tại file " + b_name + "\r\n";
                                }
                            }
                        }
                    }
                    // lấy file đính kèm
                    string b_url_getattack = b_url_contract + id.Text;
                    var client_attack = new RestClient(b_url_getattack);
                    client_attack.Timeout = -1;
                    var request_attack = new RestRequest(Method.GET);

                    IRestResponse response_attack = client_attack.Execute(request_attack);
                    if (response_attack.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string b_goc_attack = response_attack.Content.Replace("\\", "");
                        b_goc_attack = b_goc_attack.Substring(1, b_goc_attack.Length - 2);

                        JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            MissingMemberHandling = MissingMemberHandling.Ignore
                        };
                        var resultStr = JsonConvert.DeserializeObject<AttachResult>(b_goc_attack, serializerSettings);
                        var att_list = new List<AttachFiles>();
                        att_list = resultStr.Item.AttachFiles;

                        foreach (var item in att_list)
                        {
                            var base64 = item.AttachContentBase64;
                            var b_name_attack = item.AttachFileName;

                            if (base64 != null && base64 != "")
                            {
                                string b_duongdan = directory_hopdong + "\\" + b_name_attack;
                                using (System.IO.FileStream stream = System.IO.File.Create(b_duongdan))
                                {
                                    System.Byte[] byteArray = System.Convert.FromBase64String(base64);
                                    stream.Write(byteArray, 0, byteArray.Length);
                                    LogController.LogBatchFileProcess("Lưu tài liệu đính kèm thành công: " + b_name_attack, log.Text);
                                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Lưu tài liệu đính kèm thành công: " + b_name_attack + "\r\n";
                                }
                            }
                            else
                            {
                                LogController.LogBatchFileProcess("Không tồn tại file đính kèm " + b_name_attack, log.Text);
                                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Không tồn tại file đính kèm " + b_name_attack + "\r\n";
                            }
                        }

                        //DataTable b_dt_attack = JsonStringToDataTable(b_goc_attack);
                        //if (b_dt_attack.Rows.Count > 0)
                        //{
                        //    for (int j = 0; j < b_dt_attack.Rows.Count; j++)
                        //    {
                        //        string b_name_attack = b_dt_attack.Rows[j]["AttachFileName"].ToString();
                        //        string b_main_attack = b_dt_attack.Rows[j]["Main"].ToString();
                        //        var a = b_dt_attack.Rows[j]["item"].ToString();
                        //        var json = JObject.Parse(a);

                        //        string b_file_64_attack = b_dt_attack.Rows[j]["item"].ToString().Replace("AttachContentBase64:", "");
                        //        b_file_64_attack = b_file_64_attack.Replace(",\"", "\"CMCTS\"");
                        //        b_file_64_attack = b_file_64_attack.Replace(",", "..");
                        //        b_file_64_attack = b_file_64_attack.Replace("\"CMCTS\"", ",\"");
                        //        if (b_file_64_attack != null && b_file_64_attack != "")
                        //        {
                        //            string b_duongdan = directory_hopdong + "\\" + b_name_attack;
                        //            using (System.IO.FileStream stream = System.IO.File.Create(b_duongdan))
                        //            {
                        //                System.Byte[] byteArray = System.Convert.FromBase64String(b_file_64_attack);
                        //                stream.Write(byteArray, 0, byteArray.Length);
                        //                LogController.LogBatchFileProcess("Lưu tài liệu đính kèm thành công: " + b_name_attack, log.Text);
                        //                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Lưu tài liệu đính kèm thành công: " + b_name_attack;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            LogController.LogBatchFileProcess("Không tồn tại file đính kèm " + b_name_attack, log.Text);
                        //            txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Không tồn tại file đính kèm " + b_name_attack;
                        //        }
                        //    }

                        //}

                    }
                    // lấy file bằng chứng
                    if (bangchung.Checked == true)
                    {
                        string b_url_getbangchung = b_url_bangchung + id.Text;

                        var client_bangchung = new RestClient(b_url_getbangchung);
                        client_contract.Timeout = -1;
                        var request_bangchung = new RestRequest(Method.GET);

                        IRestResponse response_bangchung = client_bangchung.Execute(request_bangchung);
                        if (response_bangchung.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string b_goc3 = response_bangchung.Content.Replace("\\", "");
                            DataTable b_dt3 = JsonStringToDataTable(b_goc3);
                            if (b_dt3.Rows.Count > 0)
                            {
                                for (int j = 0; j < b_dt3.Rows.Count; j++)
                                {
                                    string b_file_bangchung64 = b_dt3.Rows[j]["ContentBase64"].ToString().Replace("AttachContentBase64:", "");
                                    if (b_file_bangchung64 != null && b_file_bangchung64 != "")
                                    {
                                        string b_duongdan = directory_hopdong + "\\" + "bangchung.pdf";
                                        using (System.IO.FileStream stream = System.IO.File.Create(b_duongdan))
                                        {
                                            System.Byte[] byteArray = System.Convert.FromBase64String(b_file_bangchung64);
                                            stream.Write(byteArray, 0, byteArray.Length);
                                            LogController.LogBatchFileProcess("Lưu bằng chứng thành công", log.Text);
                                            txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Lưu bằng chứng thành công\r\n";
                                        }
                                    }
                                    else
                                    {
                                        LogController.LogBatchFileProcess("Chưa hoàn thành chứng từ, hợp đồng không có file bằng chứng", log.Text);
                                        txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Chưa hoàn thành chứng từ, hợp đồng không có file bằng chứng\r\n";
                                    }
                                }
                            }
                        }
                    }
                    // lưu số id vào thư mục
                    string b_duongdan_id = directory_hopdong + "\\" + id.Text + ".txt";
                    using (StreamWriter sw = File.CreateText(b_duongdan_id))
                    {
                        sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
                        sw.WriteLine("ID hop dong: {0}", id.Text);
                        LogController.LogBatchFileProcess("Khởi tạo ID thành công, hoàn tất lưu hợp đồng số:" + id.Text, log.Text);
                        txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- Khởi tạo ID thành công, hoàn tất lưu hợp đồng số:" + id.Text + "\r\n";
                    }
                }
                else
                {
                    LogController.LogBatchFileProcess("ERROR:Hợp đồng chưa có file dữ liệu: " + id.Text, log.Text);
                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "ERROR:Hợp đồng chưa có file dữ liệu: " + id.Text + "\r\n";
                }
            }
            catch (Exception ex)
            {

                LogController.LogBatchFileProcess("ERROR: " + ex.ToString(), log.Text);
                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + "- ERROR: " + ex.ToString() + "\r\n";
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            // Tính toán vị trí mới cho nhãn (label) dựa trên kích thước cửa sổ form
            int labelX = this.Width - 80;  // Giữ label ở bên phải theo chiều ngang
            int labelY = this.Height - 60; // Giữ label ở dưới theo chiều dọc

            // Cập nhật vị trí mới cho nhãn
            lblphienban.Location = new Point(labelX, labelY);
        }

        // Ẩn lặp lại theo ngày
        //private void chBox_Timer_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chBox_Timer.Checked)
        //    {
        //        hengio.Enabled = true;
        //        hengio.Value = 1;
        //        date_From.Enabled = false;
        //        date_To.Enabled = false;
        //    }
        //    else
        //    {
        //        hengio.Enabled = false;
        //        hengio.Value = 0;
        //        date_From.Enabled = true;
        //        date_To.Enabled = true;
        //    }
        //}

        private void btn_getListCompanyID_Click(object sender, EventArgs e)
        {
            IRestResponse response = ExecuteGetRequest(b_url_getCompany);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JObject.Parse(response.Content)["items"].ToList();
                var ls_resource = new List<object>();
                ls_resource.Add(new { id = "", name = "--- Tất cả công ty ---" });
                if (result.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin công ty");
                    this.ma_congty.DataSource = ls_resource;
                    return;
                }

                for (var i = 0; i < result.Count(); i++)
                {
                    var obj = new
                    {
                        id = result[i]["CompanyId"].ToString(),
                        name = result[i]["CompanyName"].ToString()
                    };
                    ls_resource.Add(obj);
                }

                this.ma_congty.DataSource = ls_resource;
                this.ma_congty.DisplayMember = "name";
                this.ma_congty.ValueMember = "id";
            }
        }

        private void ma_congty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string CompanyKey = ma_congty.SelectedValue.ToString();
                var ls_resource = new List<object>();
                if (string.IsNullOrEmpty(CompanyKey))
                {
                    this.ma_phongban.DataSource = ls_resource;
                    return;
                }
                b_url_getDepartment = "https://api.econtract.cmcts.vn/department/list?APIKey=" + apikey.Text + "&AccessCode=" + madonvi.Text + "&CompanyKey=" + CompanyKey;

                var b_response = getDepartments(b_url_getDepartment);

                if (b_response == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin phòng ban");
                    this.ma_phongban.DataSource = ls_resource;
                    return;
                }
                ls_resource.Add(new { id = "", name = "--- Tất cả phòng ban ---" });
                for (var i = 0; i < b_response.Count(); i++)
                {
                    var obj = new
                    {
                        id = b_response[i]["DepartmentId"].ToString(),
                        name = b_response[i]["DepartmentName"].ToString()
                    };
                    ls_resource.Add(obj);
                }

                this.ma_phongban.DataSource = ls_resource;
                this.ma_phongban.DisplayMember = "name";
                this.ma_phongban.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menu_chucnang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // chức năng = 2 : Export excel
            if (menu_chucnang.SelectedValue.ToString() == "2")
            {
                field_extend.Enabled = true;
                bangchung.Enabled = false;
                bangchung.Checked = false;
                allow_overwrite.Checked = false;
                allow_overwrite.Enabled = false;
            }
            else
            {
                field_extend.Enabled = false;
                bangchung.Enabled = true;
                bangchung.Checked = true;
                allow_overwrite.Enabled = true;
            }
        }
        public void RemoveText(object sender, EventArgs e)
        {
            if (field_extend.Text == default_field_extend)
            {
                field_extend.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(field_extend.Text))
                field_extend.Text = default_field_extend;
        }

        public static List<JToken> getDepartments(string b_url_getDepartment)
        {
            IRestResponse response = ExecuteGetRequest(b_url_getDepartment);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JObject.Parse(response.Content)["items"].ToList();
                if (result.Count > 0)
                {
                    return result;
                }

            }
            return null;
        }

        public static IRestResponse ExecuteGetRequest(string b_url)
        {
            var client = new RestClient(b_url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;
            request.AddHeader("Content-Type", "application/json");

            return client.Execute(request);
        }

        public static DataTable getAllApartmentCode()
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("DepartmentId");
            _dt.Columns.Add("DepartmentCode");
            IRestResponse response = ExecuteGetRequest(b_url_getCompany);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JObject.Parse(response.Content)["items"].ToList();
                if (result.Count > 0)
                {
                    for (var i = 0; i < result.Count(); i++)
                    {
                        var companyID = result[i]["CompanyId"].ToString();
                        var b_url = "https://api.econtract.cmcts.vn/department/list?APIKey=" + b_api_key + "&AccessCode=" + b_ma_dvi + "&CompanyKey=" + companyID;
                        var department = getDepartments(b_url);
                        if(department != null)
                        {
                            for (var dpt = 0; dpt < department.Count(); dpt++)
                            {
                                var DepartmentId = department[dpt]["DepartmentId"].ToString();
                                var DepartmentCode = department[dpt]["DepartmentCode"].ToString();
                                DataRow _row = _dt.NewRow();
                                _row["DepartmentId"] = DepartmentId;
                                _row["DepartmentCode"] = DepartmentCode ?? DepartmentId;
                                bool tim_col = _dt.AsEnumerable().Any(row => DepartmentId == row.Field<string>("DepartmentId"));
                                if (!tim_col)
                                {
                                    _dt.Rows.Add(_row);
                                }
                            }
                        }
                    }
                }
            }
            return _dt;
        }

        private void btn_getQuantityInvoice_Click(object sender, EventArgs e)
        {
            txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Bắt đầu lấy số lượng hóa đơn --\r\n";
            try
            {
                int pageNumber = 1;
                if (int.TryParse(txtPageNumber.Text.ToString(), out pageNumber))
                {
                    if(pageNumber < 1)
                    {
                        MessageBox.Show("Số trang hóa phải bắt đầu từ 1");
                        txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Kết thúc do xảy ra lỗi --\r\n";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Số trang hóa đơn để trống hoặc sai định dạng");
                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Kết thúc do xảy ra lỗi --\r\n";
                    return;
                }
                DateTime FromDate = this.date_From.Value.Date, toDate = this.date_To.Value.Date;
                var kq = DateTime.Compare(FromDate, toDate);
                if (DateTime.Compare(FromDate, toDate) > 0)
                {
                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Kết thúc do xảy ra lỗi --\r\n";
                    MessageBox.Show("Lỗi nhập Thời gian bắt đầu lớn hơn Thời gian kết thúc.");
                    return;
                }
                // Ẩn lặp lại theo ngày
                //if (this.chBox_Timer.Checked)
                //{
                //    if (hengio.Value <= 0)
                //    {
                //        MessageBox.Show("Số ngày lặp lại phải lớn hơn 0 ");
                //        txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Kết thúc do xảy ra lỗi --\r\n";
                //        return;
                //    }
                //    else
                //    {
                //        FromDate = DateTime.Now.Date;
                //        toDate = DateTime.Now.Date;
                //    }
                //}
                bool _isAllowOverwrite = allow_overwrite.Checked;

                var client = new RestClient(b_url_list);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11;
                request.AddHeader("Content-Type", "application/json");

                dynamic body = new ExpandoObject();
                body.CompanyId = ma_congty.SelectedValue ?? "";
                body.DepartmentId = ma_phongban.SelectedValue ?? "";
                body.SortType = "ASC";
                body.BothSigned = hinhthuc.SelectedValue.ToString() == "1" ? 1 : 0;
                body.PartnerSigned = hinhthuc.SelectedValue.ToString() == "2" ? 1 : 0;
                body.OfficeSigned = hinhthuc.SelectedValue.ToString() == "3" ? 1 : 0;
                body.FromDate = FromDate.ToString("dd/MM/yyyy");
                body.ToDate = toDate.ToString("dd/MM/yyyy");
                body.Segment = pageNumber - 1;
                body.PageSize = 100;

                var json_body = JsonConvert.SerializeObject(body);
                request.AddParameter("application/json", json_body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonString = response.Content;
                    var jsonObject = JObject.Parse(jsonString);
                    bool mess = (bool)jsonObject["Found"];
                    if (!mess)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu");
                        txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- " + (string)jsonObject["Message"] + "--\r\n";
                        txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Kết thúc do xảy ra lỗi --\r\n";
                        return;
                    }
                    var items = jsonObject["Items"];

                    DataTable b_dt = JsonStringToDataTable(items);
                    // Kiểm tra danh sách thư mục chứa hợp đồng đã tải. loại bỏ lấy về nếu không cho ghi đè
                    string[] fileArray = Directory.GetFiles(thumuc.Text, "*.txt", SearchOption.AllDirectories);
                    if (!_isAllowOverwrite)
                    {
                        if (fileArray.Length > 0)
                        {
                            for (int b = 0; b < fileArray.Length; b++)
                            {
                                string b_loai = fileArray[b].ToString();
                                string b_id_luu = Path.GetFileName(b_loai).Replace(".txt", "");
                                P_BO_HANG(ref b_dt, "DocumentID", b_id_luu);
                            }
                        }
                    }
                    // Ghi lại số lượng file có thể lấy
                    txtQuantity.Text = b_dt.Rows.Count.ToString();
                }
                else
                {
                    LogController.LogBatchFileProcess("ERROR: Kiểm tra lại mã đơn vị hoặc APIKey", log.Text);
                    txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- ERROR: Kiểm tra lại mã đơn vị hoặc APIKey --\r\n";
                }
                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- Hoàn thành lấy số lượng hóa đơn --\r\n";
            }
            catch (Exception ex)
            {
                LogController.LogBatchFileProcess("ERROR: " + ex.ToString(), log.Text);
                txtResult.Text += DateTime.Now.ToString(CONST._DATETIME_FORMAT) + " -- ERROR: " + ex.ToString();
            }
        }
    }
}
