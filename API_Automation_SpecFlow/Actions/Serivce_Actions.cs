using API_Automation_SpecFlow.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Automation_SpecFlow.Helpers;
using NUnit.Framework;

namespace API_Automation_SpecFlow.Actions
{
    public static  class  Serivce_Actions
    {
        public static CreatedUserResponse Post_CreateUser(CreateUserRequest userRequest , string url)
        {    RestClient restclient = new RestClient();
             RestRequest request = new RestRequest(Helpers.Helpers.createUserReq(), Method.Post);
             RestResponse response;

            restclient = new RestClient(Helpers.Helpers.getBaseURL());
            request.AddJsonBody(JsonConvert.SerializeObject(userRequest));
            request.RequestFormat = DataFormat.Json;

            response = restclient.Execute(request);
            Assert.AreEqual(response.StatusCode.ToString(), "Created");
            return JsonConvert.DeserializeObject<CreatedUserResponse>(response.Content.ToString()); 

        }


        public static ListUserResponse get_ListUser(string url)
        {
            RestClient restclient = new RestClient();
            RestRequest request = new RestRequest(Helpers.Helpers.getListUserUrl(), Method.Get);
            RestResponse response;

            restclient = new RestClient(Helpers.Helpers.getBaseURL());            
            request.RequestFormat = DataFormat.Json;

            response = restclient.Execute(request);
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
            return JsonConvert.DeserializeObject<ListUserResponse>(response.Content.ToString());

        }

        public static SingleUserResponse get_SingleUser(string url)
        {
            RestClient restclient = new RestClient();
            RestRequest request = new RestRequest(Helpers.Helpers.getSingleUserUrl(), Method.Get);
            RestResponse response;

            restclient = new RestClient(Helpers.Helpers.getBaseURL());
            request.RequestFormat = DataFormat.Json;

            response = restclient.Execute(request);
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
            return JsonConvert.DeserializeObject<SingleUserResponse>(response.Content.ToString());

        }

        public static UpdatedUserResponse Update_User(UpdateUserRequest userRequest, string url)
        {
            RestClient restclient = new RestClient();
            RestRequest request = new RestRequest(Helpers.Helpers.updateUserReq(), Method.Put);
            RestResponse response;

            restclient = new RestClient(Helpers.Helpers.getBaseURL());
            request.AddJsonBody(JsonConvert.SerializeObject(userRequest));
            request.RequestFormat = DataFormat.Json;

            response = restclient.Execute(request);
            Assert.AreEqual(response.StatusCode.ToString(), "OK");
            return JsonConvert.DeserializeObject<UpdatedUserResponse>(response.Content.ToString());

        }


    }
}
