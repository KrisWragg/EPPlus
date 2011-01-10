﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.DataValidation.Formulas.Contracts;
using OfficeOpenXml.DataValidation;

namespace ExcelPackageTest.DataValidation
{
    [TestClass]
    public class ListDataValidationTests : ValidationTestBase
    {
        private ExcelDataValidationList _validation;

        [TestInitialize]
        public void Setup()
        {
            SetupTestData();
            _validation = _sheet.Workbook.Worksheets[1].DataValidation.AddListValidation("A1");
        }

        [TestCleanup]
        public void Cleanup()
        {
            CleanupTestData();
        }

        [TestMethod]
        public void ListDataValidation_FormulaIsSet()
        {
            Assert.IsNotNull(_validation.Formula);
        }

        [TestMethod]
        public void ListDataValidation_WhenOneItemIsAddedCountIs1()
        {
            // Act
            _validation.Formula.Values.Add("test");

            // Assert
            Assert.AreEqual(1, _validation.Formula.Values.Count);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void ListDataValidation_ShouldThrowWhenNoFormulaOrValueIsSet()
        {
            _validation.Validate();
        }
    }
}