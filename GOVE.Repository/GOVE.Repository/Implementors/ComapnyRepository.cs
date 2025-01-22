using GOVE.Models.Constants;
using GOVE.Models;
using GOVE.Models.Requests;
using GOVE.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GOVE.Models.Constants.Constants;

namespace GOVE.Repository.Implementors
{
    public class ComapnyRepository(string connectionString) : ICompanyRepository
    {
        public async Task<CompanyMasterRequest> Get_CompanyMasterRepository(int? companyId)
        {
            var company = new CompanyMasterRequest();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = SqlCommandConstants.FOS_Get_Company_Details;
                cmd.Parameters.Add(new SqlParameter(SqlParameterConstants.COMPANY_ID, companyId));
                var dataAdapter = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        var dr = ds.Tables[0].Rows[0];
                        company = new CompanyMasterRequest
                        {
                            CompanyId = Convert.ToInt64(dr[SqlColumnNames.CompanyID]),
                            Company_Code = Convert.ToString(dr[SqlColumnNames.CompanyCode]),
                            CompanyName = Convert.ToString(dr[SqlColumnNames.CompanyName]),
                            CompanyAddress = Convert.ToString(dr[SqlColumnNames.CompanyAddress]),
                            City  = Convert.ToString(dr[SqlColumnNames.City]),
                            State = Convert.ToString(dr[SqlColumnNames.State]),
                            Country = Convert.ToString(dr[SqlColumnNames.Country]),
                            ZipCode = Convert.ToString(dr[SqlColumnNames.ZipCode]),
                            ConstitutionalStatusId = Convert.ToString(dr[SqlColumnNames.ConstitutionalStatusId]),
                            CDCEOHeadName = Convert.ToString(dr[SqlColumnNames.CDCEOHeadName]),
                            CDTelephoneNumber = Convert.ToString(dr[SqlColumnNames.CDTelephoneNumber]),
                            CDMobileNumber = Convert.ToString(dr[SqlColumnNames.CDMobileNumber]),
                            CDEmailID = Convert.ToString(dr[SqlColumnNames.CDEmailID]),
                            CDWebsite = Convert.ToString(dr[SqlColumnNames.CDWebsite]),
                            CDSysAdminUserCode = Convert.ToString(dr[SqlColumnNames.CDSysAdminUserCode]),
                            CDSysAdminUserPassword = Convert.ToString(dr[SqlColumnNames.CDSysAdminUserPassword]),
                            ODAddress1 = Convert.ToString(dr[SqlColumnNames.ODAddress1]),
                            ODCity = Convert.ToString(dr[SqlColumnNames.ODCity]),
                            ODState = Convert.ToString(dr[SqlColumnNames.ODState]),
                            ODCountry = Convert.ToString(dr[SqlColumnNames.ODCountry]),
                            ODZipCode = Convert.ToString(dr[SqlColumnNames.ODZipCode]),
                            ODDateOfIncorporation = Convert.ToString(dr[SqlColumnNames.ODDateOfIncorporation]),
                            ODRegLicNumber = Convert.ToString(dr[SqlColumnNames.ODRegLicNumber]),
                            ODValidityOfRegLicNumber = Convert.ToString(dr[SqlColumnNames.ODValidityOfRegLicNumber]),
                            OD_Income_Tax_PAN_Number = Convert.ToString(dr[SqlColumnNames.OD_Income_Tax_PAN_Number]),
                            Currency = Convert.ToString(dr[SqlColumnNames.Currency]),
                            OD_Remarks = Convert.ToString(dr[SqlColumnNames.OD_Remarks]),
                            Active = Convert.ToString(dr[SqlColumnNames.Active]),
                            GST_Number = Convert.ToString(dr[SqlColumnNames.GST_Number]),
                            Constitutional_Status = Convert.ToString(dr[SqlColumnNames.Constitutional_Status]),
                        };
                    }
                }
                return company;
            }
        }
    }
}
