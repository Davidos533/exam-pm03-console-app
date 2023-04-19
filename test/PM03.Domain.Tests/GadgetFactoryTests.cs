using NUnit.Framework;
using System;

namespace PM03.Domain.Tests
{
    /// <summary>
    /// Юнит-тест 
    /// </summary>
    public class GadgetFactoryTests
    {
        /// <summary>
        /// Тест проверки на null значение
        /// </summary>
        [Test]
        public void SortByDescending_NullArray_Exception()
        {
            // arrange
            var factory = new GadgetFactory(null);

            // act
            var exec = new Action(()=>factory.SortByDescending());

            // assert
            Assert.Throws<ArgumentException>(() =>
            {
                exec();
            });
        }

        /// <summary>
        /// Тест сортировки по модели
        /// </summary>

        [Test]
        public void SortByDescending_NotSortedArray_DescendingSortedArrayByModel()
        {
            // arrange
            var smartphones = new Smartphone[]
                {
                    new Smartphone()
                    {
                        Model = "X10"
                    },
                    new Smartphone()
                    {
                        Model = "C12"
                    },
                    new Smartphone()
                    {
                        Model = "A1"
                    },
                };

            var factory = new GadgetFactory(new Smartphone[]
                {
                    smartphones[2],
                    smartphones[0],
                    smartphones[1]
                });

            // act
            factory.SortByDescending();

            // assert
            Assert.IsTrue(factory.Smartphones[0].Model == smartphones[0].Model);
            Assert.IsTrue(factory.Smartphones[1].Model == smartphones[1].Model);
            Assert.IsTrue(factory.Smartphones[2].Model == smartphones[2].Model);
        }

        /// <summary>
        /// Тест сортировки по диагонали
        /// </summary>
        [Test]
        public void SortByDescending_NotSortedArray_DescendingSortedArrayByDiagonal()
        {
            // arrange
            var smartphones = new Smartphone[]
                {
                    new Smartphone()
                    {
                        Digonal = 1.7
                    },
                    new Smartphone()
                    {
                        Digonal = 1.4
                    },
                    new Smartphone()
                    {
                        Digonal = 1.2
                    },
                };

            var factory = new GadgetFactory(new Smartphone[]
                {
                    smartphones[2],
                    smartphones[0],
                    smartphones[1]
                });

            // act
            factory.SortByDescending();

            // assert
            Assert.IsTrue(factory.Smartphones[0].Model == smartphones[0].Model);
            Assert.IsTrue(factory.Smartphones[1].Model == smartphones[1].Model);
            Assert.IsTrue(factory.Smartphones[2].Model == smartphones[2].Model);
        }

        /// <summary>
        /// Тест сортировки по модели и по диагнали
        /// </summary>
        [Test]
        public void SortByDescending_NotSortedArray_DescendingSortedArrayByDiagonalAndByModel()
        {
            // arrange
            var smartphones = new Smartphone[]
                {
                    new Smartphone()
                    {
                        Model = "Z10",
                        Digonal = 1.2
                    },
                    new Smartphone()
                    {
                        Model = "X10",
                        Digonal = 1.7
                    },
                    new Smartphone()
                    {
                        Model = "X10",
                        Digonal = 1.4
                    },
                };

            var factory = new GadgetFactory(new Smartphone[]
                {
                    smartphones[2],
                    smartphones[1],
                    smartphones[0]
                });

            // act
            factory.SortByDescending();

            // assert
            Assert.IsTrue(factory.Smartphones[0].Model == smartphones[0].Model);
            Assert.IsTrue(factory.Smartphones[1].Model == smartphones[1].Model);
            Assert.IsTrue(factory.Smartphones[2].Model == smartphones[2].Model);
        }
    }
}