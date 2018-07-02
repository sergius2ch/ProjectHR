using ExcelDataReader;
using NLog;
using ProjectHR.DataAccessLayer;
using ProjectHR.Domains;
using ProjectHR.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ProjectHR.Controllers
{
    public class ExcelImporter
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private static FileInfo _fileInfo;
        private static DataSet _dset;

        public ExcelImporter()
        {
            _fileInfo = null;
            _dset = null;
        }

        public static bool SelectExcelFile()
        {
            bool isSelected = false;
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.xls*)|*.xls*";
            openFileDialog.InitialDirectory = MainController.ProjectLocation;
            DialogResult result = openFileDialog.ShowDialog();
            _fileInfo = null;
            if (result == DialogResult.OK)
            {
                string fname = openFileDialog.FileName.Trim();
                _fileInfo = new FileInfo(fname);
                isSelected = _fileInfo.Exists;
            }
            return isSelected;
        }

        public static bool OpenReadExcelFile()
        {
            if (_fileInfo == null) return false;
            using (FileStream fs = _fileInfo.OpenRead())
            {
                string ext = _fileInfo.Extension;
                // для 2003 xls - Binary; 2007 xlsx - Xml
                using (var xreader = ext == ".xls" ?
                                 ExcelReaderFactory.CreateBinaryReader(fs) :
                                 ExcelReaderFactory.CreateOpenXmlReader(fs))
                {
                    _dset = null;
                    try
                    {
                        _dset = xreader.AsDataSet();
                    }
                    catch(Exception ex)
                    {
                        Inspection.CurrentException = ex;
                        Inspection.NotifyError(log, "Error processing xls-file");
                        return false;
                    }
                }
                return true;
            }
        }

        private static Employee ProceedRecord(DataRow row)
        {
            string firstname = row[0].ToString();
            string secondname = row[1].ToString();
            string lastname = row[2].ToString();
            DateTime.TryParse(row[3].ToString(), out DateTime birthDate);
            DateTime.TryParse(row[4].ToString(), out DateTime emplDate);
            string skillName = row[5].ToString().Trim().ToLower();
            int.TryParse(row[6].ToString().Trim(), out int probPeriod);
            string depName = row[7].ToString().Trim().ToLower();
            //---------------------------------------------------------
            SkillLevel skillLevel = DataManager
                                    .SkillLevels
                                    .FirstOrDefault(s => s.Description.ToLower().Contains(skillName));

            Probation probation = DataManager
                                    .ProbationPeriods
                                    .FirstOrDefault(s => s.DurationInMonth == probPeriod);
            Department department = DataManager
                                    .Departments
                                    .FirstOrDefault(s => s.Title.ToLower().Contains(depName));
            var empl = new Employee()
            {
                Firstname = firstname,
                Secondname = secondname,
                Lastname = lastname,
                Birthday = birthDate,
                EmploymentDate = emplDate,
                Skill = skillLevel,
                ProbationPeriod = probation,
                CurrentDepartment = department
            };
            return empl;
        }

        async public static Task ProceedEmployeesRecordsAsync(IProgress<int> progress)
        {
            if (_dset == null || _dset.Tables.Count == 0) return;
            await Task.Run(() =>
            {
                DataTable table = _dset.Tables[0];
                for (int i = 1; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    //---------------------------
                    Employee empl = ProceedRecord(row);
                    DataManager.Instance.AddEmployee(empl);
                    progress.Report(i*100/ table.Rows.Count);
                }
                progress.Report(100);
            });
        }

    }
}
