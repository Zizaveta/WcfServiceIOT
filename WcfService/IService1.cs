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
                   UriTemplate = "/ReceiveData?name={Name}&temp={Temperature}&humidity={Humidity}&press={Pressure}")]
        void ReceiveData(string Name, string Temperature, string Humidity, string Pressure);


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

        [OperationContract]
        [WebGet(
                  ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "/ReturnDataByName?name={Name}")]
        TempData[] ReturnDataByName(string Name);

        [WebGet(
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/Return20LastDataByName?name={Name}")]
        TempData[] Return20LastDataByName(string Name);

        [WebGet(
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "/Return10LastDataByName?name={Name}")]
        TempData[] Return10LastDataByName(string Name);

        [WebGet(
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "/Return20LastData")]
        TempData[] Return20LastData();

        [WebGet(
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "/ReternAllDataByDay?date={Date}")]
        TempData[] ReturnAllDataByDay(string Date);

        [WebGet(
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "/AvgDataByDay?date={Date}")]
        TempData AvgDataByDay(string Date);
    }
}
