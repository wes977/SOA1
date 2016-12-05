using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SOA1_C
{
    enum commandType
    {
        DRC = 0,
        INF = 1,
        SOA = 2,
        SRV,
        ARG,
        MCH,
        RSP,
        PUB

    }
    enum registryCommands
    {
        REG = 0,
        UNREG,
        QUERY,
        PUB_SERVICE,
        QUERY_SERVICE,
        EXEC_SERVICE
    }
    enum ERRORS
    {

    }

    struct DRCstruct
    {
        private string _teamName;
        private string _teamID;
        public string teamName
        {
            get
            {
                return _teamName;
            }
            set
            {
                _teamName = value;
            }
        }
        public string teamID
        {
            get
            {
                return _teamID;
            }
            set
            {
                _teamID = value;
            }
        }
    }
    struct INFstruct
    {
        private string _teamName;
        private string _teamID;
        private string _serviceTag;
        public string teamName
        {
            get
            {
                return _teamName;
            }
            set
            {
                _teamName = value;
            }
        }
        public string teamID
        {
            get
            {
                return _teamID;
            }
            set
            {
                _teamID = value;
            }
        }
        public string serviceTag
        {
            get
            {
                return _serviceTag;
            }
            set
            {
                _serviceTag = value;
            }
        }
    }
    struct SOAstruct
    {
        private string _allGood;
        private string _errorCode;
        private string _errorMessage;
        private string _numSegments;
        public string allGood
        {
            get
            {
                return _allGood;
            }
            set
            {
                _allGood = value;
            }
        }
        public string errorCode
        {
            get
            {
                return _errorCode;
            }
            set
            {
                _errorCode = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
            }
        }
        public string numSegments
        {
            get
            {
                return _numSegments;
            }
            set
            {
                _numSegments = value;
            }
        }
    }
    struct SRVstruct
    {
        private string _teamName;
        private string _serviceName;
        private string _securityLevel;
        private string _numARGS;
        private string _numResponses;
        private string _description;

        public string teamName
        {
            get
            {
                return _teamName;
            }
            set
            {
                _teamName = value;
            }
        }
        public string serviceName
        {
            get
            {
                return _serviceName;
            }
            set
            {
                _serviceName = value;
            }
        }
        public string securityLevel
        {
            get
            {
                return _securityLevel;
            }
            set
            {
                _securityLevel = value;
            }
        }

        public string numARGS
        {
            get
            {
                return _numARGS;
            }
            set
            {
                _numARGS = value;
            }
        }
        public string numResponses
        {
            get
            {
                return _numResponses;
            }
            set
            {
                _numResponses = value;
            }
        }

        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }
    struct ARGstruct
    {
        private string _argPosition;
        private string _argName;
        private string _argDataType;
        private string _argManOpt;
        private string _value;
        public string argPosition
        {
            get
            {
                return _argPosition;
            }
            set
            {
                _argPosition = value;
            }
        }
        public string argName
        {
            get
            {
                return _argName;
            }
            set
            {
                _argName = value;
            }
        }
        public string argDataType
        {
            get
            {
                return _argDataType;
            }
            set
            {
                _argDataType = value;
            }
        }
        public string argManOpt
        {
            get
            {
                return _argManOpt;
            }
            set
            {
                _argManOpt = value;
            }
        }
        public string value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

    }
    struct MCHstruct
    {
        private string _IP;
        private string _port;
        public string port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }
        public string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                _IP = value;
            }
        }
    }
    struct RSPstruct
    {
        private string _position;
        private string _name;
        private string _DataType;
        private string _value;
        public string position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string DataType
        {
            get
            {
                return _DataType;
            }
            set
            {
                _DataType = value;
            }
        }
        public string value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
    struct PUBstruct
    {
        private string _allGood;
        private string _errorCode;
        private string _errorMessage;
        private string _numSegments;


        public string allGood
        {
            get
            {
                return _allGood;
            }
            set
            {
                _allGood = value;
            }
        }
        public string errorCode
        {
            get
            {
                return _errorCode;
            }
            set
            {
                _errorCode = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
            }
        }
        public string numSegments
        {
            get
            {
                return _numSegments;
            }
            set
            {
                _numSegments = value;
            }
        }
    }

    //builder 
    class HL7Builder
    {

        char separatingChar = '|';
        private string[] aCommandTypes = { "DRC", "INF", "SOA", "SRV", "ARG", "MCH", "RSP", "PUB" };
        private string[] aRegistryCommands = { "REG-TEAM", "UNREG-TEAM", "QUERY-TEAM", "PUB-SERVICE", "QUERY-SERVICE", "EXEC-SERVICE" };
        private string message;
        private int BOMunicode = 11;
        private int EOSunicode = 13;
        private int EOMunicode = 28;
        public string teamCode;
        public string teamName;
        public string errorMesg;
        public DRCstruct DRCs = new DRCstruct();
        public INFstruct INFs = new INFstruct();
        public SOAstruct SOAs = new SOAstruct();
        public SRVstruct SRVs = new SRVstruct();
        public ARGstruct ARGs = new ARGstruct();
        public MCHstruct MCHs = new MCHstruct();
        public RSPstruct RSPs = new RSPstruct();
        public PUBstruct PUBs = new PUBstruct();
        public List<ARGstruct> argList = new List<ARGstruct>();
        public List<RSPstruct> rspList = new List<RSPstruct>();
        //private Validation validate = new Validation();
        public string RegistryStringBuilder(commandType CT, registryCommands c, string teamName, string teamID)
        {
            return message = string.Format("{0}|{1}|{2}|{3}|", aCommandTypes[(int)CT], aRegistryCommands[(int)c], teamName, teamID);
        }

        public commandType HLStringDebuilder(string input)
        {
            commandType returner;
            char BOM = (char)BOMunicode;
            char EOS = (char)EOSunicode;
            char EOM = (char)EOMunicode;
            input = input.Replace(BOM, ' ');
            input = input.Replace(EOS, ' ');
            input = input.Replace(EOM, ' ');
            string[] values = input.Split(separatingChar);
            int commandTypeNum = 0;
            int i = 0;
            foreach (string s in aCommandTypes) // Checking what command it is 
            {
                if (s == values[0].Trim())
                {
                    commandTypeNum = i;
                }
                i++;
            }

            switch (commandTypeNum)
            {
                //case (int)commandType.DRC:
                //    DRCcommand(values);
                //    break;
                case (int)commandType.INF:
                    INFcommand(values);
                    break;
                case (int)commandType.SOA:
                    SOAcommand(values);
                    break;
                case (int)commandType.SRV:
                    SRVcommand(values);
                    break;
                case (int)commandType.ARG:
                    ARGcommand(values);
                    break;
                case (int)commandType.MCH:
                    MCHcommand(values);
                    break;
                case (int)commandType.RSP:
                    RSPcommand(values);
                    break;
                case (int)commandType.PUB:
                    PUBcommand(values);
                    break;
            }
            returner = (commandType)commandTypeNum;
            return returner;
        }

        public commandType breakingUpString(string input)
        {
            rspList.Clear();
            char BOM = (char)BOMunicode;
            char EOS = (char)EOSunicode;
            char EOM = (char)EOMunicode;
            input = input.Replace(BOM, ' ');
            input = input.Replace(EOM, ' ');
            string regexer = "";
            regexer += EOS;
            string[] lines = Regex.Split(input, regexer);

            foreach (string l in lines)
            {
                Logger.Log(l);
                HLStringDebuilder(l);
            }
            return commandType.SOA;
        }

        public string SOAerrorChecker()
        {
            string returner = "";
            if (SOAs.allGood == "OK")
            {
                returner = "All Good in the hood Team ID" + SOAs.errorCode;
                teamCode = SOAs.errorCode;
                teamName = SOAs.errorMessage;
            }
            else
            {
                returner = "ERROR (" + SOAs.errorCode + ") : " + SOAs.errorMessage;
            }
            return returner;
        }

        public string PUBerrorChecker()
        {
            string returner = "";
            if (PUBs.allGood == "OK")
            {
                returner = "All Good in the hood";
            }
            else
            {
                returner = "ERROR (" + PUBs.errorCode + ") : " + PUBs.errorMessage;
            }
            return returner;
        }

        // DECONSTRUCTORS 
        private void DRCcommand(string[] inputValues)
        {

            if (inputValues.Count() == 4)
            {
                DRCs.teamName = inputValues[2];
                DRCs.teamID = inputValues[3];
            }
            else
            {
                // ERROR not enough values 
            }

        }
        private void INFcommand(string[] inputValues)
        {


            INFs.teamName = inputValues[1];
            INFs.teamID = inputValues[2];
            INFs.serviceTag = inputValues[3];


        }
        private void SOAcommand(string[] inputValues)
        {

            SOAs.allGood = inputValues[1];
            SOAs.errorCode = inputValues[2];
            SOAs.errorMessage = inputValues[3];
            SOAs.numSegments = inputValues[4];


        }
        private void SRVcommand(string[] inputValues)
        {
            SRVs.teamName = inputValues[1];
            SRVs.serviceName = inputValues[2];
            SRVs.securityLevel = inputValues[3];
            SRVs.numARGS = inputValues[4];
            SRVs.numResponses = inputValues[5];
            SRVs.description = inputValues[6];
        }
        private void ARGcommand(string[] inputValues)
        {
            ARGs.argPosition = inputValues[1];
            ARGs.argName = inputValues[2];
            ARGs.argDataType = inputValues[3];
            ARGs.argManOpt = inputValues[4];
            argList.Add(ARGs);
        }
        private void MCHcommand(string[] inputValues)
        {

            MCHs.IP = inputValues[1];
            MCHs.port = inputValues[2];
        }
        private void RSPcommand(string[] inputValues)
        {

            RSPs.position = inputValues[1];
            RSPs.name = inputValues[2];
            RSPs.DataType = inputValues[3];
            RSPs.value = inputValues[4];
            rspList.Add(RSPs);
        }
        private void PUBcommand(string[] inputValues)
        {

            PUBs.allGood = inputValues[1];
            PUBs.errorCode = inputValues[2];
            PUBs.errorMessage = inputValues[3];
        }

        // Command builder
        public string DRCBuilder(DRCstruct builder, registryCommands command)
        {
            string cmd = "";
            cmd = string.Format("DRC|{0}|{1}|{2}|", aRegistryCommands[(int)command], builder.teamName, builder.teamID);
            Logger.Log(cmd);
            return cmd;
        }
        public string INFBuilder(INFstruct builder)
        {
            string cmd = "";
            cmd = string.Format("INF|{0}|{1}|{2}|", builder.teamName, builder.teamID, builder.serviceTag);
            Logger.Log(cmd);
            return cmd;
        }
        public string SOABuilder(SOAstruct builder)
        {
            string cmd = "";
            cmd = string.Format("SOA|{0}|{1}|{2}|{3}|", builder.allGood, builder.errorCode, builder.errorMessage, builder.numSegments);
            Logger.Log(cmd);
            return cmd;
        }
        public string SRVBuilder(SRVstruct builder)
        {
            string cmd = "";
            cmd = string.Format("SRV|{0}|{1}|{2}|{3}|{4}|{5}|", builder.teamName, builder.serviceName, builder.securityLevel, builder.numARGS, builder.numResponses, builder.description);
            Logger.Log(cmd);
            return cmd;
        }
        public string ARGBuilder(ARGstruct builder)
        {
            string cmd = "";
            cmd = string.Format("ARG|{0}|{1}|{2}|{3}|{4}|", builder.argPosition, builder.argName, builder.argDataType, builder.argManOpt, builder.value);
            Logger.Log(cmd);
            return cmd;
        }
        public string MCHBuilder(MCHstruct builder)
        {
            string cmd = "";
            cmd = string.Format("MCH|{0}|{1}|", builder.IP, builder.port);
            Logger.Log(cmd);
            return cmd;
        }
        public string RSPBuilder(RSPstruct builder)
        {
            string cmd = "";
            cmd = string.Format("RSP|{0}|{1}|{2}|{3}|", builder.position, builder.name, builder.DataType, builder.value);
            Logger.Log(cmd);
            return cmd;
        }
        public string PUBBuilder(PUBstruct builder)
        {
            string cmd = "";
            cmd = string.Format("PUB|{0}|{1}|{2}|{3}|", builder.allGood, builder.errorCode, builder.errorMessage, builder.numSegments);
            Logger.Log(cmd);
            return cmd;
        }
    }
}
