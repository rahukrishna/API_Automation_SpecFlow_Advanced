using API_Automation_SpecFlow.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API_Automation_SpecFlow.ResponseValidators
{
    public static class ResponseValidations
    {
        public static bool createUserResponseValidations(CreatedUserResponse createdUserResponse, string name , string job)
        {
            try
            {
                Assert.IsNotNull(createdUserResponse);
                Assert.AreEqual(createdUserResponse.name, name);
                Assert.AreEqual(createdUserResponse.job, job);
                Assert.IsNotNull(createdUserResponse.id);
                Assert.IsNotNull(createdUserResponse.createdAt);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public static bool listUserResponseValidations(ListUserResponse listResponse)
        {
            try
            {
                Assert.IsNotNull(listResponse);
                Assert.IsNotNull(listResponse.per_page);
                Assert.IsNotNull(listResponse.page);
                Assert.IsNotNull(listResponse.data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool singleUserResponseValidations(SingleUserResponse singleUserResponse)
        {
            try
            {
                
                Assert.IsNotNull(singleUserResponse);                
                Assert.IsNotNull(singleUserResponse.support);
                Assert.IsNotNull(singleUserResponse.data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool updateUserResponseValidations(UpdatedUserResponse updatedUserResponse, string name, string newJob)
        {
            try
            {

                Assert.IsNotNull(updatedUserResponse);
                Assert.IsNotNull(updatedUserResponse.updatedAt);
                Assert.AreEqual(updatedUserResponse.name, name);
                Assert.AreEqual(updatedUserResponse.job, newJob);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool patchUserResponseValidations(UpdatedUserResponse updatedUserResponse, string name, string newJob)
        {
            try
            {

                Assert.IsNotNull(updatedUserResponse);
                Assert.IsNotNull(updatedUserResponse.updatedAt);
                Assert.AreEqual(updatedUserResponse.name, name);
                Assert.AreEqual(updatedUserResponse.job, newJob);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
