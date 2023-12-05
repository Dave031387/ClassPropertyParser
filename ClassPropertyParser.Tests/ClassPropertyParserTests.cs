namespace ClassPropertyParser
{
    using System.Reflection;
    using TestModels;

    public class ClassPropertyParserTests
    {
        private enum PropertyType
        {
            All,
            Collection,
            Complex,
            Simple
        }

        [Fact]
        public void ClassPropertyParser_DefaultConstructor_InitializesEmptyLists()
        {
            // Arrange/Act
            ClassPropertyParser parser = new();

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.All, parser);
        }

        [Fact]
        public void ClassPropertyParser_NullClassType_InitializesEmptyLists()
        {
            // Arrange/Act
            ClassPropertyParser parser = new(null!);

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.All, parser);
        }

        [Fact]
        public void ClassPropertyParser_TestModel1_GetsAllClassTypesInSameAssembly()
        {
            // Arrange/Act
            ClassPropertyParser parser = new(typeof(TestModel1));

            // Assert
            VerifyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.All, parser);
        }

        [Fact]
        public void ClassPropertyParser_TestModel5_GetsAllClassTypesInSameAssembly()
        {
            // Arrange/Act
            ClassPropertyParser parser = new(typeof(TestModel5));

            // Assert
            VerifyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.All, parser);
        }

        [Fact]
        public void GetAllProperties_NullClassType_ClearsAllPropertyLists()
        {
            // Arrange
            ClassPropertyParser parser = new(typeof(TestModel1));
            parser.GetAllProperties(typeof(TestModel5));

            // Act
            parser.GetAllProperties(null!);

            // Assert
            VerifyEmptyPropertyLists(PropertyType.All, parser);
        }

        [Fact]
        public void GetAllProperties_TestModel1_GetsAllPropertiesForTestModel1()
        {
            // Arrange
            ClassPropertyParser parser = new();

            // Act
            parser.GetAllProperties(typeof(TestModel1));

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyTM1PropertyList(PropertyType.All, parser);
        }

        [Fact]
        public void GetAllProperties_TestModel5_GetsAllPropertiesForTestModel5()
        {
            // Arrange
            ClassPropertyParser parser = new();

            // Act
            parser.GetAllProperties(typeof(TestModel5));

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyTM5PropertyList(PropertyType.All, parser);
        }

        [Fact]
        public void GetClassTypes_NullClassType_ClearsAllLists()
        {
            // Arrange
            ClassPropertyParser parser = new(typeof(TestModel5));

            // Act
            _ = parser.GetClassTypes(null!);

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.All, parser);
        }

        [Fact]
        public void GetClassTypes_TestModel1_GetsAllClassTypesInSameAssemblyAndClearsPropertyLists()
        {
            // Arrange
            ClassPropertyParser parser = new();
            parser.GetAllProperties(typeof(TestModel5));

            // Act
            parser.GetClassTypes(typeof(TestModel1));

            // Assert
            VerifyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.All, parser);
        }

        [Fact]
        public void GetClassTypes_TestModel5_GetsAllClassTypesInSameAssemblyAndClearsPropertyLists()
        {
            // Arrange
            ClassPropertyParser parser = new();
            parser.GetAllProperties(typeof(TestModel5));

            // Act
            parser.GetClassTypes(typeof(TestModel5));

            // Assert
            VerifyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.All, parser);
        }

        [Fact]
        public void GetCollectionProperties_NullClassType_ClearsCollectionPropertyList()
        {
            // Arrange
            ClassPropertyParser parser = new();
            parser.GetAllProperties(typeof(TestModel5));

            // Act
            _ = parser.GetCollectionProperties(null!);

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.Collection, parser);
            VerifyTM5PropertyList(PropertyType.Complex, parser);
            VerifyTM5PropertyList(PropertyType.Simple, parser);
        }

        [Fact]
        public void GetCollectionProperties_TestModel1_GetsAllCollectionPropertiesForClassType()
        {
            // Arrange
            ClassPropertyParser parser = new();
            parser.GetAllProperties(typeof(TestModel5));

            //Act
            _ = parser.GetCollectionProperties(typeof(TestModel1));

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyTM1PropertyList(PropertyType.Collection, parser);
            VerifyTM5PropertyList(PropertyType.Complex, parser);
            VerifyTM5PropertyList(PropertyType.Simple, parser);
        }

        [Fact]
        public void GetCollectionProperties_TestModel5_GetsAllCollectionPropertiesForClassType()
        {
            // Arrange
            ClassPropertyParser parser = new();

            //Act
            _ = parser.GetCollectionProperties(typeof(TestModel5));

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyTM5PropertyList(PropertyType.Collection, parser);
            VerifyEmptyPropertyLists(PropertyType.Complex, parser);
            VerifyEmptyPropertyLists(PropertyType.Simple, parser);
        }

        [Fact]
        public void GetComplexProperties_NullClassType_ClearsComplexPropertyList()
        {
            // Arrange
            ClassPropertyParser parser = new();
            parser.GetAllProperties(typeof(TestModel5));

            // Act
            _ = parser.GetComplexProperties(null!);

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.Complex, parser);
            VerifyTM5PropertyList(PropertyType.Collection, parser);
            VerifyTM5PropertyList(PropertyType.Simple, parser);
        }

        [Fact]
        public void GetComplexProperties_TestModel1_GetsAllComplexPropertiesForClassType()
        {
            // Arrange
            ClassPropertyParser parser = new();
            parser.GetAllProperties(typeof(TestModel5));

            //Act
            _ = parser.GetComplexProperties(typeof(TestModel1));

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyTM1PropertyList(PropertyType.Complex, parser);
            VerifyTM5PropertyList(PropertyType.Collection, parser);
            VerifyTM5PropertyList(PropertyType.Simple, parser);
        }

        [Fact]
        public void GetComplexProperties_TestModel5_GetsAllComplexPropertiesForClassType()
        {
            // Arrange
            ClassPropertyParser parser = new();

            //Act
            _ = parser.GetComplexProperties(typeof(TestModel5));

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyTM5PropertyList(PropertyType.Complex, parser);
            VerifyEmptyPropertyLists(PropertyType.Collection, parser);
            VerifyEmptyPropertyLists(PropertyType.Simple, parser);
        }

        [Fact]
        public void GetSimpleProperties_NullClassType_ClearsSimplePropertyList()
        {
            // Arrange
            ClassPropertyParser parser = new();
            parser.GetAllProperties(typeof(TestModel5));

            // Act
            _ = parser.GetSimpleProperties(null!);

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyEmptyPropertyLists(PropertyType.Simple, parser);
            VerifyTM5PropertyList(PropertyType.Collection, parser);
            VerifyTM5PropertyList(PropertyType.Complex, parser);
        }

        [Fact]
        public void GetSimpleProperties_TestModel1_GetsAllSimplePropertiesForClassType()
        {
            // Arrange
            ClassPropertyParser parser = new();
            parser.GetAllProperties(typeof(TestModel5));

            //Act
            _ = parser.GetSimpleProperties(typeof(TestModel1));

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyTM1PropertyList(PropertyType.Simple, parser);
            VerifyTM5PropertyList(PropertyType.Collection, parser);
            VerifyTM5PropertyList(PropertyType.Complex, parser);
        }

        [Fact]
        public void GetSimpleProperties_TestModel5_GetsAllSimplePropertiesForClassType()
        {
            // Arrange
            ClassPropertyParser parser = new();

            //Act
            _ = parser.GetSimpleProperties(typeof(TestModel5));

            // Assert
            VerifyEmptyClassTypeList(parser);
            VerifyTM5PropertyList(PropertyType.Simple, parser);
            VerifyEmptyPropertyLists(PropertyType.Collection, parser);
            VerifyEmptyPropertyLists(PropertyType.Complex, parser);
        }

        [Theory]
        [InlineData(typeof(string), "System.String")]
        [InlineData(typeof(List<string>), "System.Collections.Generic.List<System.String>")]
        [InlineData(typeof(int[]), "System.Int32[]")]
        [InlineData(typeof(Dictionary<int, DateTime>), "System.Collections.Generic.Dictionary<System.Int32,System.DateTime>")]
        public void GetTypeName_ValidType_ReturnsFullTypeName(Type type, string expectedTypeName)
        {
            // Act
            string actualTypeName = ClassPropertyParser.GetTypeName(type);

            // Assert
            actualTypeName
                .Should()
                .Be(expectedTypeName);
        }

        private static List<string> GetPropertyNames(IEnumerable<PropertyInfo> propertyInfos)
            => propertyInfos.Select(t => t.Name).ToList();

        private static void VerifyClassTypeList(IClassPropertyParser parser)
        {
            List<Type> expectedTypes = new()
            {
                typeof(TestModel1),
                typeof(TestModel2),
                typeof(TestModel3),
                typeof(TestModel4),
                typeof(TestModel5)
            };

            parser.ClassTypes
                .Should()
                .NotBeNull();
            parser.ClassTypes
                .Should()
                .HaveCount(expectedTypes.Count);
            parser.ClassTypes
                .Should()
                .Contain(expectedTypes);
        }

        private static void VerifyEmptyClassTypeList(IClassPropertyParser parser)
        {
            parser.ClassTypes
                .Should()
                .NotBeNull();
            parser.ClassTypes
                .Should()
                .BeEmpty();
        }

        private static void VerifyEmptyPropertyLists(PropertyType propertyType, IClassPropertyParser parser)
        {
            if (propertyType is PropertyType.All or PropertyType.Collection)
            {
                parser.CollectionProperties
                    .Should()
                    .NotBeNull();
                parser.CollectionProperties
                    .Should()
                    .BeEmpty();
            }

            if (propertyType is PropertyType.All or PropertyType.Complex)
            {
                parser.ComplexProperties
                    .Should()
                    .NotBeNull();
                parser.ComplexProperties
                    .Should()
                    .BeEmpty();
            }

            if (propertyType is PropertyType.All or PropertyType.Simple)
            {
                parser.SimpleProperties
                    .Should()
                    .NotBeNull();
                parser.SimpleProperties
                    .Should()
                    .BeEmpty();
            }
        }

        private static void VerifyPropertyList(PropertyType propertyType, List<string> propertyNames, IClassPropertyParser parser)
        {
            if (propertyType is PropertyType.Collection)
            {
                parser.CollectionProperties
                    .Should()
                    .HaveCount(propertyNames.Count);
                GetPropertyNames(parser.CollectionProperties)
                    .Should()
                    .Contain(propertyNames);
            }
            else if (propertyType is PropertyType.Complex)
            {
                parser.ComplexProperties
                    .Should()
                    .HaveCount(propertyNames.Count);
                GetPropertyNames(parser.ComplexProperties)
                    .Should()
                    .Contain(propertyNames);
            }
            else if (propertyType is PropertyType.Simple)
            {
                parser.SimpleProperties
                    .Should()
                    .HaveCount(propertyNames.Count);
                GetPropertyNames(parser.SimpleProperties)
                    .Should()
                    .Contain(propertyNames);
            }
        }

        private static void VerifyTM1PropertyList(PropertyType propertyType, IClassPropertyParser parser)
        {
            if (propertyType is PropertyType.All or PropertyType.Collection)
            {
                VerifyEmptyPropertyLists(PropertyType.Collection, parser);
            }

            if (propertyType is PropertyType.All or PropertyType.Complex)
            {
                VerifyEmptyPropertyLists(PropertyType.Complex, parser);
            }

            if (propertyType is PropertyType.All or PropertyType.Simple)
            {
                List<string> expectedProperties = new()
                {
                    nameof(TestModel1.TM1Property1),
                    nameof(TestModel1.TM1Property2),
                    nameof(TestModel1.TM1Property3),
                    nameof(TestModel1.TM1Property4)
                };
                VerifyPropertyList(PropertyType.Simple, expectedProperties, parser);
            }
        }

        private static void VerifyTM5PropertyList(PropertyType propertyType, IClassPropertyParser parser)
        {
            if (propertyType is PropertyType.All or PropertyType.Collection)
            {
                List<string> expectedProperties = new()
                {
                    nameof(TestModel5.TM5Property2),
                    nameof(TestModel5.TM5Property5)
                };
                VerifyPropertyList(PropertyType.Collection, expectedProperties, parser);
            }

            if (propertyType is PropertyType.All or PropertyType.Complex)
            {
                List<string> expectedProperties = new()
                {
                    nameof(TestModel5.TM5Property4),
                    nameof(TestModel5.TM5Property6)
                };
                VerifyPropertyList(PropertyType.Complex, expectedProperties, parser);
            }

            if (propertyType is PropertyType.All or PropertyType.Simple)
            {
                List<string> expectedProperties = new()
                {
                    nameof(TestModel5.TM5Property1),
                    nameof(TestModel5.TM5Property3)
                };
                VerifyPropertyList(PropertyType.Simple, expectedProperties, parser);
            }
        }
    }
}