using API_Automation_SpecFlow.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using API_Automation_SpecFlow.Actions;
using API_Automation_SpecFlow.ResponseValidators;

namespace API_Automation_SpecFlow.StepDefinitions
{
    [Binding]
    public class CreateUserRequestAPIValidationsStepDefinitions
    {
        string? url;
        string? bodydata;        
        CreateUserRequest? JsonData;
        CreatedUserResponse? createdUserResponse;

        [Given(@"Want to create the user request")]
        public void GivenWantToCreateTheUserRequest()
        {           
            url = Helpers.Helpers.getBaseURL();
        }

        [When(@"passing (.+) and (.+) in the body")]
        public void WhenPassingNameAndJobInTheBody(string name, string job)
        {
            bodydata = Helpers.BodyData.createRequestData(name, job);
            JsonData = JsonConvert.DeserializeObject<CreateUserRequest>(bodydata);                    
           
        }

        [When(@"retrying the data")]
        public void WhenRetryingTheData()
        {
            if(JsonData!=null && url!=null)
            createdUserResponse = Serivce_Actions.Post_CreateUser(JsonData, url);           
        }

        [Then(@"I should get the response of created request with name (.+) and job (.+)")]
        public void ThenIShouldGetTheResponseOfCreatedRequestWithNameAndJob(string name, string job)
        {
            if(createdUserResponse!=null)
            Assert.IsTrue(ResponseValidations.createUserResponseValidations(createdUserResponse, name, job));
        }

    }
}
