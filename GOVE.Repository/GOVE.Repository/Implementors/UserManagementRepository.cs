using GOVE.Models.Constants;
using GOVE.Models;
using GOVE.Models.Entities;
using GOVE.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GOVE.Models.Constants.Constants;

namespace GOVE.Repository.Implementors
{
    public class UserManagementRepository(string connectionString) : IUsermanagementRepository
    {
        public async Task<UserTranslanderEntites> getUsertranslander(int? companyId, int? userId)
        {
            var userdetails = new UserTranslanderEntites();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = SqlCommandConstants.Sysad_Get_UserMaster;
                cmd.Parameters.Add(new SqlParameter(SqlParameterConstants.USER_MANAGEMENT_COMPANY_ID, companyId));
                cmd.Parameters.Add(new SqlParameter(SqlParameterConstants.USER_MANAGEMENT_USER_ID, userId));
                var dataAdapter = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                dataAdapter.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        var dr = ds.Tables[0].Rows[0];
                        userdetails = new UserTranslanderEntites
                        {
                            UserID = Convert.ToInt32(dr[SqlColumnNames.UserID]),
                            UserCode = Convert.ToString(dr[SqlColumnNames.UserCode]),
                            UserName = Convert.ToString(dr[SqlColumnNames.UserName]),
                            MobileNumber = Convert.ToString(dr[SqlColumnNames.MobileNumberr]),
                            Designation = Convert.ToString(dr[SqlColumnNames.Designation]),
                            Userlevel = Convert.ToString(dr[SqlColumnNames.UserLevel]),
                            EmailID = Convert.ToString(dr[SqlColumnNames.Email]),
                        };
                    }
                }
                return userdetails;
            }
        }
    }
}
