using System;

// Namespace aliases to resolve conflicts
using AReport = TwoLibrariesWithSameClassName.CompanyA.Reporting.Report;
using BReport = TwoLibrariesWithSameClassName.CompanyB.Analytics.Report;

class Program
{
    static void Main()
    {
        AReport reportA = new AReport();
        reportA.Generate();

        BReport reportB = new BReport();
        reportB.Generate();
    }
}
