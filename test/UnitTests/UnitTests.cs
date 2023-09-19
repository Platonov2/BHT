using DataBase;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "����� �� ����� ���� ������ 0")]
        public void Box_Length_Less_Zero()
        {
            int length = -1;
            Box box = new(1, length, 1, 1, 1, new DateOnly(2023, 01, 01), new DateOnly(2023, 04, 01));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "���� ������������ �� ����� ���� ����� ���� ��������� ����� ��������")]
        public void Box_ExpirationDate_LessThan_ManufacturingDate()
        {
            DateOnly expirationDate = new(2023, 01, 01);
            DateOnly manufacturingDate = new(2023, 02, 01);

            Box box = new(1, 1, 1, 1, 1, manufacturingDate, expirationDate);
        }

        [TestMethod]
        public void Pallet_CheckVolume_AfterBoxAdding()
        {
            int palletLength = 10;
            int palletWidth = 10;
            int palletHeight = 10;
            int palletVolume = palletLength * palletWidth * palletHeight;

            int boxLength = 5;
            int boxWidth = 5;
            int boxHeight = 5;
            int boxVolume = boxLength * boxWidth * boxHeight;

            int expected = palletVolume + boxVolume;

            Box box = new(1, boxLength, boxWidth, boxHeight, 10, new DateOnly(2023, 01, 01), new DateOnly(2023, 02, 01));
            List<Box> boxes = new();
            boxes.Add(box);
            Pallet pallet = new(1, palletLength, palletWidth, palletHeight, 1, boxes);

            int actual = pallet.TotalVolume;
            Assert.AreEqual(expected, actual, "������������ ������ ������");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "�����/������ ������� ������ �����/������ �������")]
        public void Pallet_AddingBox_WithSizeGreater_ThenPalletSize()
        {
            int palletLength = 10;
            int palletWidth = 10;
            int palletHeight = 10;

            int boxLength = 15;
            int boxWidth = 15;
            int boxHeight = 15;

            Box box = new(1, boxLength, boxWidth, boxHeight, 10, new DateOnly(2023, 01, 01), new DateOnly(2023, 02, 01));
            List<Box> boxes = new();
            boxes.Add(box);
            Pallet pallet = new(1, palletLength, palletWidth, palletHeight, 1, boxes);
        }

        [TestMethod]
        public void Pallet_AddingBox_WithHeightGreater_ThenPalletHeight()
        {
            int palletLength = 10;
            int palletWidth = 10;
            int palletHeight = 10;

            int boxLength = 5;
            int boxWidth = 5;
            int boxHeight = 15;

            Box box = new(1, boxLength, boxWidth, boxHeight, 10, new DateOnly(2023, 01, 01), new DateOnly(2023, 02, 01));
            List<Box> boxes = new();
            boxes.Add(box);
            Pallet pallet = new(1, palletLength, palletWidth, palletHeight, 1, boxes);
        }
    }
}