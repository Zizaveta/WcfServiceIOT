using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
                   Method = "GET",
                   UriTemplate = "/ReceiveData?temp={Temperature}&alt={Altitude}&press={Pressure}")]
        void ReceiveData(string Temperature, string Altitude, string Pressure);


        [OperationContract]
        [WebGet(
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "/ReturnLastData")]
        TempData ReturnLastData();

        [OperationContract]
        [WebGet(
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "/ReturnCountOfData")]
        string ReturnCountOfData();

        [OperationContract]
        [WebGet(
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "/ReturnAllData")]
        TempData[] ReturnAllData();


    }
}
