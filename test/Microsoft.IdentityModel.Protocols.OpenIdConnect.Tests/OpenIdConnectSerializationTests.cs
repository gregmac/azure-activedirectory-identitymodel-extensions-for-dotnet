// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.IdentityModel.TestUtils;
using Xunit;

namespace Microsoft.IdentityModel.Protocols.OpenIdConnect.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenIdConnectSerializationTests
    {
        [Theory, MemberData(nameof(SerializationMixedCaseTheoryData))]
        public void SerializationMixedCase(OpenIdConnectTheoryData theoryData)
        {
            var context = TestUtilities.WriteHeader($"{this}.SerializationMixedCase", theoryData);

            try
            {
                OpenIdConnectConfiguration configuration = new OpenIdConnectConfiguration(theoryData.Json);
                OpenIdConnectConfiguration configurationMixedCase = new OpenIdConnectConfiguration(theoryData.JsonMixedCase);

                theoryData.ExpectedException.ProcessNoException(context);
                IdentityComparer.AreEqual(configuration, configurationMixedCase, context);
            }
            catch (Exception ex)
            {
                theoryData.ExpectedException.ProcessException(ex, context);
            }

            TestUtilities.AssertFailIfErrors(context);
        }

        public static TheoryData<OpenIdConnectTheoryData> SerializationMixedCaseTheoryData
        {
            get
            {
                TheoryData<OpenIdConnectTheoryData> theoryData = new TheoryData<OpenIdConnectTheoryData>();
                theoryData.Add(new OpenIdConnectTheoryData("MixedCaseNames")
                {
                    Json = OpenIdConfigData.MixedCaseNames,
                    JsonMixedCase = OpenIdConfigData.LowerCaseNames
                });

                return theoryData;
            }
        }

        [Theory, MemberData(nameof(SerializationCorrectnessTheoryData))]
        public void SerializationCorrectness(OpenIdConnectTheoryData theoryData)
        {
            var context = TestUtilities.WriteHeader($"{this}.SerializationCorrectness", theoryData);

            try
            {
                OpenIdConnectConfiguration configuration = new OpenIdConnectConfiguration(theoryData.Json);
                theoryData.ExpectedException.ProcessNoException(context);

                IdentityComparer.AreEqual(configuration, theoryData.CompareTo, context);
            }
            catch (Exception ex)
            {
                theoryData.ExpectedException.ProcessException(ex, context);
            }

            TestUtilities.AssertFailIfErrors(context);
        }

        public static TheoryData<OpenIdConnectTheoryData> SerializationCorrectnessTheoryData
        {
            get
            {
                TheoryData<OpenIdConnectTheoryData> theoryData = new TheoryData<OpenIdConnectTheoryData>();

                theoryData.Add(new OpenIdConnectTheoryData("AccountsGoogleCom")
                {
                    Json = OpenIdConfigData.AccountsGoogleCom,
                    CompareTo = OpenIdConfigData.AccountsGoogleComConfig,
                });

                theoryData.Add(new OpenIdConnectTheoryData("ArrayAtBeginning")
                {
                    Json = OpenIdConfigData.ArrayAtBeginning,
                    CompareTo = OpenIdConfigData.ArrayConfig,
                });

                theoryData.Add(new OpenIdConnectTheoryData("ArrayAtEnd")
                {
                    Json = OpenIdConfigData.ArrayAtEnd,
                    CompareTo = OpenIdConfigData.ArrayConfig,
                });

                theoryData.Add(new OpenIdConnectTheoryData("ArrayInMiddle")
                {
                    Json = OpenIdConfigData.ArrayInMiddle,
                    CompareTo = OpenIdConfigData.ArrayConfig,
                });

                theoryData.Add(new OpenIdConnectTheoryData("ObjectAtBegining")
                {
                    Json = OpenIdConfigData.ObjectAtBegining,
                    CompareTo = OpenIdConfigData.ObjectConfig,
                });

                theoryData.Add(new OpenIdConnectTheoryData("ObjectAtEnd")
                {
                    Json = OpenIdConfigData.ObjectAtEnd,
                    CompareTo = OpenIdConfigData.ObjectConfig,
                });

                theoryData.Add(new OpenIdConnectTheoryData("ObjectInMiddle")
                {
                    Json = OpenIdConfigData.ObjectInMiddle,
                    CompareTo = OpenIdConfigData.ObjectConfig,
                });

                //theoryData.Add(new OpenIdConnectTheoryData("UnknownStringAtEnd")
                //{
                //    Json = OpenIdConfigData.UnknownStringAtEnd,
                //    JsonMixedCase = OpenIdConfigData.UnknownStringAtEnd,
                //    //JsonMixedCase = OpenIdConfigData.LowerCaseNames
                //});

                //theoryData.Add(new OpenIdConnectTheoryData("UnknownObjectAtEnd")
                //{
                //    Json = OpenIdConfigData.UnknownObjectAtEnd,
                //    JsonMixedCase = OpenIdConfigData.UnknownObjectAtEnd,
                //    //JsonMixedCase = OpenIdConfigData.LowerCaseNames
                //});

                //theoryData.Add(new OpenIdConnectTheoryData("MixedCaseNames")
                //{
                //    Json = OpenIdConfigData.MixedCaseNames,
                //    JsonMixedCase = OpenIdConfigData.LowerCaseNames
                //});

                //theoryData.Add(new OpenIdConnectTheoryData("Working")
                //{
                //    Json = OpenIdConfigData.Working,
                //    JsonMixedCase = OpenIdConfigData.Working
                //});

                //theoryData.Add(new OpenIdConnectTheoryData("NotWorking")
                //{
                //    Json = OpenIdConfigData.NotWorking,
                //    JsonMixedCase = OpenIdConfigData.NotWorking
                //});

                //theoryData.Add(new OpenIdConnectTheoryData("DuplicatesWithMixedCaseNames")
                //{
                //    Json = OpenIdConfigData.NoDuplicates,
                //    JsonMixedCase = OpenIdConfigData.MixedCaseWithDuplicates
                //});

                return theoryData;
            }
        }
    }
}
