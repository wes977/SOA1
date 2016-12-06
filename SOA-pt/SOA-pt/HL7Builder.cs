////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	hl7builder.cs
//
// summary:	Implements the hl 7builder class
// 
//  TEAM : WES , JEN, Niels , Alex
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SOA_pt
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent command types. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    enum commandType
    {
        /// <summary>   An enum constant representing the drc option. </summary>
        DRC = 0,
        /// <summary>   An enum constant representing the inf option. </summary>
        INF = 1,
        /// <summary>   An enum constant representing the soa option. </summary>
        SOA = 2,
        /// <summary>   An enum constant representing the Server option. </summary>
        SRV,
        /// <summary>   An enum constant representing the Argument option. </summary>
        ARG,
        /// <summary>   An enum constant representing the mch option. </summary>
        MCH,
        /// <summary>   An enum constant representing the rsp option. </summary>
        RSP,
        /// <summary>   An enum constant representing the pub option. </summary>
        PUB

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent registry commands. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    enum registryCommands
    {
        /// <summary>   An enum constant representing the Register option. </summary>
        REG = 0,
        /// <summary>   An enum constant representing the unreg option. </summary>
        UNREG,
        /// <summary>   An enum constant representing the query option. </summary>
        QUERY,
        /// <summary>   An enum constant representing the pub service option. </summary>
        PUB_SERVICE,
        /// <summary>   An enum constant representing the query service option. </summary>
        QUERY_SERVICE,
        /// <summary>   An enum constant representing the Execute service option. </summary>
        EXEC_SERVICE
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent errors. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    enum ERRORS
    {

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A dr cstruct. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    struct DRCstruct
    {
        /// <summary>   Name of the team. </summary>
        private string _teamName;
        /// <summary>   Identifier for the team. </summary>
        private string _teamID;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the team. </summary>
        ///
        /// <value> The name of the team. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the team. </summary>
        ///
        /// <value> The identifier of the team. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An in fstruct. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    struct INFstruct
    {
        /// <summary>   Name of the team. </summary>
        private string _teamName;
        /// <summary>   Identifier for the team. </summary>
        private string _teamID;
        /// <summary>   The service tag. </summary>
        private string _serviceTag;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the team. </summary>
        ///
        /// <value> The name of the team. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the team. </summary>
        ///
        /// <value> The identifier of the team. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the service tag. </summary>
        ///
        /// <value> The service tag. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A so astruct. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    struct SOAstruct
    {
        /// <summary>   all good. </summary>
        private string _allGood;
        /// <summary>   The error code. </summary>
        private string _errorCode;
        /// <summary>   Message describing the error. </summary>
        private string _errorMessage;
        /// <summary>   Number of segments. </summary>
        private string _numSegments;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets all good. </summary>
        ///
        /// <value> all good. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the error code. </summary>
        ///
        /// <value> The error code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the error. </summary>
        ///
        /// <value> A message describing the error. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of segments. </summary>
        ///
        /// <value> The total number of segments. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A sr vstruct. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    struct SRVstruct
    {
        /// <summary>   Name of the team. </summary>
        private string _teamName;
        /// <summary>   Name of the service. </summary>
        private string _serviceName;
        /// <summary>   The security level. </summary>
        private string _securityLevel;
        /// <summary>   Number of the rgs. </summary>
        private string _numARGS;
        /// <summary>   Number of responses. </summary>
        private string _numResponses;
        /// <summary>   The description. </summary>
        private string _description;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the team. </summary>
        ///
        /// <value> The name of the team. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the service. </summary>
        ///
        /// <value> The name of the service. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the security level. </summary>
        ///
        /// <value> The security level. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of the rgs. </summary>
        ///
        /// <value> The total number of the rgs. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of responses. </summary>
        ///
        /// <value> The total number of responses. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An archive gstruct. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    struct ARGstruct
    {
        /// <summary>   The argument position. </summary>
        private string _argPosition;
        /// <summary>   Name of the argument. </summary>
        private string _argName;
        /// <summary>   Type of the argument data. </summary>
        private string _argDataType;
        /// <summary>   The argument manager option. </summary>
        private string _argManOpt;
        /// <summary>   The value. </summary>
        private string _value;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the argument position. </summary>
        ///
        /// <value> The argument position. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the argument. </summary>
        ///
        /// <value> The name of the argument. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the argument data. </summary>
        ///
        /// <value> The type of the argument data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the argument manager option. </summary>
        ///
        /// <value> The argument manager option. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value. </summary>
        ///
        /// <value> The value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A mc hstruct. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    struct MCHstruct
    {
        /// <summary>   The IP. </summary>
        private string _IP;
        /// <summary>   The port. </summary>
        private string _port;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the port. </summary>
        ///
        /// <value> The port. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the IP. </summary>
        ///
        /// <value> The IP. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The RS pstruct. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    struct RSPstruct
    {
        /// <summary>   The position. </summary>
        private string _position;
        /// <summary>   The name. </summary>
        private string _name;
        /// <summary>   Type of the data. </summary>
        private string _DataType;
        /// <summary>   The value. </summary>
        private string _value;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the position. </summary>
        ///
        /// <value> The position. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the data. </summary>
        ///
        /// <value> The type of the data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value. </summary>
        ///
        /// <value> The value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A pu bstruct. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    struct PUBstruct
    {
        /// <summary>   all good. </summary>
        private string _allGood;
        /// <summary>   The error code. </summary>
        private string _errorCode;
        /// <summary>   Message describing the error. </summary>
        private string _errorMessage;
        /// <summary>   Number of segments. </summary>
        private string _numSegments;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets all good. </summary>
        ///
        /// <value> all good. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the error code. </summary>
        ///
        /// <value> The error code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a message describing the error. </summary>
        ///
        /// <value> A message describing the error. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of segments. </summary>
        ///
        /// <value> The total number of segments. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   builder. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class HL7Builder
    {

        /// <summary>   The separating character. </summary>
        char separatingChar = '|';
        /// <summary>   List of types of the commands. </summary>
        private string[] aCommandTypes = { "DRC", "INF", "SOA", "SRV", "ARG", "MCH", "RSP", "PUB" };
        /// <summary>   The registry commands. </summary>
        private string[] aRegistryCommands = { "REG-TEAM", "UNREG-TEAM", "QUERY-TEAM", "PUB-SERVICE", "QUERY-SERVICE", "EXEC-SERVICE" };
        /// <summary>   The message. </summary>
        private string message;
        /// <summary>   The bo municode. </summary>
        private int BOMunicode = 11;
        /// <summary>   The eo sunicode. </summary>
        private int EOSunicode = 13;
        /// <summary>   The eo municode. </summary>
        private int EOMunicode = 28;

        /// <summary>   The team code. </summary>
        public string teamCode;
        /// <summary>   Name of the team. </summary>
        public string teamName;
        /// <summary>   The dr create struct. </summary>
        public DRCstruct DRCs = new DRCstruct();
        /// <summary>   The in file system. </summary>
        public INFstruct INFs = new INFstruct();
        /// <summary>   The so as. </summary>
        public SOAstruct SOAs = new SOAstruct();
        /// <summary>   The sr vs. </summary>
        public SRVstruct SRVs = new SRVstruct();
        /// <summary>   The archive gs. </summary>
        public ARGstruct ARGs = new ARGstruct();
        /// <summary>   The mc hs. </summary>
        public MCHstruct MCHs = new MCHstruct();
        /// <summary>   The RS ps. </summary>
        public RSPstruct RSPs = new RSPstruct();
        /// <summary>   The pu bs. </summary>
        public PUBstruct PUBs = new PUBstruct();
        /// <summary>   List of arguments. </summary>
        public List<ARGstruct> argList = new List<ARGstruct>();
        /// <summary>   List of rsps. </summary>
        public List<RSPstruct> rspList = new List<RSPstruct>();
        //private Validation validate = new Validation();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Registry string builder. </summary>
        ///
        ///  
        ///
        /// <param name="CT">       The ct. </param>
        /// <param name="c">        The registryCommands to process. </param>
        /// <param name="teamName"> Name of the team. </param>
        /// <param name="teamID">   Identifier for the team. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RegistryStringBuilder(commandType CT, registryCommands c, string teamName, string teamID)
        {
            return message = string.Format("{0}|{1}|{2}|{3}|", aCommandTypes[(int)CT], aRegistryCommands[(int)c], teamName, teamID);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Hl string debuilder. </summary>
        ///
        ///  
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A commandType. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
                case (int)commandType.DRC:
                    DRCcommand(values);
                    break;
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Breaking up string. </summary>
        ///
        ///  
        ///
        /// <param name="input">    The input. </param>
        ///
        /// <returns>   A commandType. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public commandType breakingUpString(string input)
        {
            argList.Clear();
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   So aerror checker. </summary>
        ///
        ///  
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string SOAerrorChecker()
        {
            string returner = "";
            if (SOAs.allGood == "OK")
            {
                returner = "All Good in the hood Team ID" + SOAs.errorCode;
                Console.WriteLine(returner);
                teamCode = SOAs.errorCode;
                teamName = SOAs.errorMessage;
            }
            else
            {
                returner = "ERROR (" + SOAs.errorCode + ") : " + SOAs.errorMessage;
                Console.WriteLine(returner);
            }
            return returner;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Pu berror checker. </summary>
        ///
        ///  
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PUBerrorChecker()
        {
            string returner = "";
            if (PUBs.allGood == "OK")
            {
                returner = "All Good in the hood";
                Console.WriteLine(returner);
            }
            else
            {
                returner = "ERROR (" + PUBs.errorCode + ") : " + PUBs.errorMessage;
                Console.WriteLine(returner);
            }
            return returner;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   DECONSTRUCTORS. </summary>
        ///
        ///  
        ///
        /// <param name="inputValues">  The input values. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   In fcommand. </summary>
        ///
        ///  
        ///
        /// <param name="inputValues">  The input values. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void INFcommand(string[] inputValues)
        {


            INFs.teamName = inputValues[1];
            INFs.teamID = inputValues[2];
            INFs.serviceTag = inputValues[3];


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   So acommand. </summary>
        ///
        ///  
        ///
        /// <param name="inputValues">  The input values. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SOAcommand(string[] inputValues)
        {


            SOAs.allGood = inputValues[1];
            SOAs.errorCode = inputValues[2];
            SOAs.errorMessage = inputValues[3];
            SOAs.numSegments = inputValues[4];


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sr vcommand. </summary>
        ///
        ///  
        ///
        /// <param name="inputValues">  The input values. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SRVcommand(string[] inputValues)
        {
            SRVs.teamName = inputValues[1];
            SRVs.serviceName = inputValues[2];
            SRVs.securityLevel = inputValues[3];
            SRVs.numARGS = inputValues[4];
            SRVs.numResponses = inputValues[5];
            SRVs.description = inputValues[6];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Archive gcommand. </summary>
        ///
        ///  
        ///
        /// <param name="inputValues">  The input values. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ARGcommand(string[] inputValues)
        {
            ARGs.argPosition = inputValues[1];
            ARGs.argName = inputValues[2];
            ARGs.argDataType = inputValues[3];
            ARGs.argManOpt = inputValues[4];
            ARGs.value = inputValues[5];
            argList.Add(ARGs);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Mc hcommand. </summary>
        ///
        ///  
        ///
        /// <param name="inputValues">  The input values. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MCHcommand(string[] inputValues)
        {

            MCHs.IP = inputValues[1];
            MCHs.port = inputValues[2];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   RS pcommand. </summary>
        ///
        ///  
        ///
        /// <param name="inputValues">  The input values. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RSPcommand(string[] inputValues)
        {

            RSPs.position = inputValues[1];
            RSPs.name = inputValues[2];
            RSPs.DataType = inputValues[3];
            rspList.Add(RSPs);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Pu bcommand. </summary>
        ///
        ///  
        ///
        /// <param name="inputValues">  The input values. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PUBcommand(string[] inputValues)
        {

            PUBs.allGood = inputValues[1];
            PUBs.errorCode = inputValues[2];
            PUBs.errorMessage = inputValues[3];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Command builder. </summary>
        ///
        ///  
        ///
        /// <param name="builder">  The builder. </param>
        /// <param name="command">  The command. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DRCBuilder(DRCstruct builder, registryCommands command)
        {
            string cmd = "";
            cmd = string.Format("DRC|{0}|{1}|{2}|", aRegistryCommands[(int)command], builder.teamName, builder.teamID);
            Logger.Log(cmd);
            return cmd;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inf builder. </summary>
        ///
        ///  
        ///
        /// <param name="builder">  The builder. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string INFBuilder(INFstruct builder)
        {
            string cmd = "";
            cmd = string.Format("INF|{0}|{1}|{2}|", builder.teamName, builder.teamID, builder.serviceTag);
            Logger.Log(cmd);
            return cmd;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Soa builder. </summary>
        ///
        ///  
        ///
        /// <param name="builder">  The builder. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string SOABuilder(SOAstruct builder)
        {
            string cmd = "";
            cmd = string.Format("SOA|{0}|{1}|{2}|{3}|", builder.allGood, builder.errorCode, builder.errorMessage, builder.numSegments);
            Logger.Log(cmd);
            return cmd;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Server builder. </summary>
        ///
        ///  
        ///
        /// <param name="builder">  The builder. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string SRVBuilder(SRVstruct builder)
        {
            string cmd = "";
            cmd = string.Format("SRV|{0}|{1}|{2}|{3}|{4}|{5}|", builder.teamName, builder.serviceName, builder.securityLevel, builder.numARGS, builder.numResponses, builder.description);
            Logger.Log(cmd);
            return cmd;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Argument builder. </summary>
        ///
        ///  
        ///
        /// <param name="builder">  The builder. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ARGBuilder(ARGstruct builder)
        {
            string cmd = "";
            cmd = string.Format("ARG|{0}|{1}|{2}|{3}|{4}|", builder.argPosition, builder.argName, builder.argDataType, builder.argManOpt, builder.value);
            Logger.Log(cmd);
            return cmd;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Mch builder. </summary>
        ///
        ///  
        ///
        /// <param name="builder">  The builder. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string MCHBuilder(MCHstruct builder)
        {
            string cmd = "";
            cmd = string.Format("MCH|{0}|{1}|", builder.IP, builder.port);
            Logger.Log(cmd);
            return cmd;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rsp builder. </summary>
        ///
        ///  
        ///
        /// <param name="builder">  The builder. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string RSPBuilder(RSPstruct builder)
        {
            string cmd = "";
            cmd = string.Format("RSP|{0}|{1}|{2}|{3}|", builder.position, builder.name, builder.DataType, builder.value);
            Logger.Log(cmd);
            return cmd;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Pub builder. </summary>
        ///
        ///  
        ///
        /// <param name="builder">  The builder. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PUBBuilder(PUBstruct builder)
        {
            string cmd = "";
            cmd = string.Format("PUB|{0}|{1}|{2}|{3}|", builder.allGood, builder.errorCode, builder.errorMessage, builder.numSegments);
            Logger.Log(cmd);
            return cmd;
        }
    }
}
