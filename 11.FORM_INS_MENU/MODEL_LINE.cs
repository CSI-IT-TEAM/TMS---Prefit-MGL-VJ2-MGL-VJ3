using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FORM
{
    public class MODEL_LINE
    {

        private static string _Line_cd, _Line_Name, _buttonVisibleConfig;
        private static int _NumberMline;
        public string Line_cd { get { return _Line_cd; } set { _Line_cd = value; } }
        public string Line_Name { get { return _Line_Name; } set { _Line_Name = value; } }
        public int NumberMline { get { return _NumberMline; } set { _NumberMline = value; } }
        public string buttonVisibleConfig { get { return _buttonVisibleConfig; } set { _buttonVisibleConfig = value; } }
        string[] _arrMLineName = { "001", "002", "003", "004", "005", "006", "007", "008" };
        string[] _arrMLineLeaderName = { "", "", "", "", "", "", "", "" };
        string[] _arrMLineLeaderPicture = { "", "", "", "", "", "", "", "" };
        bool[] _bButtonVisible;

        public MODEL_LINE()
        {
            _Line_cd = "000";
            _Line_Name = "Unknow";
            _NumberMline = 4;
        }

        private int FindIndex(string _sMLineCD)
        {
            for (int i = 0; i < _NumberMline; i++)
            {
                if (_sMLineCD.Trim().Equals(_arrMLineName[i]))
                {
                    return i;
                }
            }
            return 9;
        }
        private bool ConvertToBool(string _sValue)
        {
            if (_sValue.Trim().ToUpper() == "TRUE" || _sValue.Trim().ToUpper() == "T")
            {
                return true;
            }
            else if (_sValue.Trim().ToUpper() == "FALSE" || _sValue.Trim().ToUpper() == "F")
            {
                return false;
            }
            return false;
        }
        public string getMLineName(int _index)
        {
            if (_index > _NumberMline) return "";
            return _arrMLineName[_index - 1];
        }
        public string getMLineLeaderName(int _index)
        {
            if (_index > _NumberMline) return "";
            return _arrMLineLeaderName[_index - 1];
        }
        public string getMLineLeaderPicture(int _index)
        {
            if (_index > _NumberMline) return "";
            return _arrMLineLeaderPicture[_index - 1];
        }


        public void setMLineName(string _iMLineCD, string _sLeaderName)
        {
            if (FindIndex(_iMLineCD) >= 9) return;
            _arrMLineLeaderName[FindIndex(_iMLineCD)] = _sLeaderName;
        }

        public void setMLinePicture(string _iMLineCD, string _sLeaderPictureFile)
        {
            if (FindIndex(_iMLineCD) >= 9) return;
            _arrMLineLeaderPicture[FindIndex(_iMLineCD)] = _sLeaderPictureFile;
        }
        public string getMLineLeaderName(string _iMLineCD)
        {
            if (FindIndex(_iMLineCD) >= 9)
                return "";
            return _arrMLineLeaderName[FindIndex(_iMLineCD)];

        }

        public string getMLineLeaderPicture(string _iMLineCD)
        {
            if (FindIndex(_iMLineCD) >= 9)
                return "";
            return _arrMLineLeaderPicture[FindIndex(_iMLineCD)];

        }

        public void setButtonVisibleConfig()
        {
            string[] listConfig = _buttonVisibleConfig.Split('/');
            if (listConfig.Length > 0)
            {
                _bButtonVisible = new bool[listConfig.Length];
                for (int i = 0; i < listConfig.Length; i++)
                {
                    _bButtonVisible[i] = ConvertToBool(listConfig[i].ToString().Trim());
                }
            }
        }
        public bool getButtonVisible(int iIndex)
        {
            return _bButtonVisible[iIndex];
        }
        public int getNumberButton()
        {
            return _bButtonVisible.Length;
        }
    }
}
