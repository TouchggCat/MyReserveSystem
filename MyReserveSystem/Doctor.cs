//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyReserveSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public int DeptID { get; set; }
        public string Education { get; set; }
        public string JobTitle { get; set; }
        public int TreatmentID { get; set; }
        public byte[] Picture { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
