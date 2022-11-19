using System;
using System.Collections.Generic;
using NUnit.Framework;
using SearchRankFinder.Core.Helpers;

namespace SearchRankFinderTests;

public class UrlBuilderTests
{
    private readonly List<(string key, string value)> TestQueryParameters = new List<(string key, string value)>()
    {
        ("q", "searchQuery"),
        ("num", "100")
    };

    [TestCase("")]
    [TestCase(null)]
    [TestCase("not a url")]
    public void ArgumentExceptionHandlingTests(string baseUrl)
    {
        Assert.Throws<ArgumentException>(() => UrlBuilder.AddQueriesToUrl(baseUrl, TestQueryParameters));
    }
    
    [TestCase("http://www.google.com/search", true, "http://www.google.com/search?q=searchQuery&num=100")]
    [TestCase("http://www.google.com/search", false, "http://www.google.com/search")]
    [TestCase("http://www.mywebsite.com.au", true, "http://www.mywebsite.com.au?q=searchQuery&num=100")]
    [TestCase("http://www.mywebsite.com.au", false, "http://www.mywebsite.com.au")]
    public void AddQueriesToUrlTests(string baseUrl, bool addQueryParameters, string expectedResult)
    {
        Assert.AreEqual(expectedResult, UrlBuilder.AddQueriesToUrl(baseUrl, addQueryParameters ? TestQueryParameters : new List<(string key, string value)>()));
    }
}