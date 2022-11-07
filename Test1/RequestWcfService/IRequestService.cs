using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RequestWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRequestService" in both code and config file together.
    [ServiceContract]
    public interface IRequestService
    {
        
        [OperationContract]
        int CheckForRequests();

        [OperationContract]
        void UpdateRequest(int requestID, bool approve);

        [OperationContract]
        GetRequestList GetInfo();
    }
    [DataContract]
    public class GetRequestList
    {
        [DataMember]
        public DataTable ReqTble
        {
            get;
            set;
        }

    }
       
}
