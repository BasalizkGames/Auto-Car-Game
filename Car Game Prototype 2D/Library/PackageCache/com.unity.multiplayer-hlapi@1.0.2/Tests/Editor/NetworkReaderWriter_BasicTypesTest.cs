using NUnit.Framework;
using UnityEngine.Networking;

#pragma warning disable 618
[TestFixture]
public class NetworkReaderWriter_BasicTypesTest
{
    private NetworkWriter writer;

    [SetUp]
    public void Setup()
    {
        writer = new NetworkWriter();
    }

    // ulong and uint cases have been taken from http://sqlite.org/src4/doc/trunk/www/varint.wiki
    private static uint[] UInt32Cases =
    {
        uint.MinValue, 240, 241, 2287, 2288, 67823, 67824, 16777215, 16777216, 4294967295, uint.MaxValue
    };
    private static ulong[] UInt64Cases =
    {
        ulong.MinValue, 240, 241, 2287, 2288, 67823, 67824, 16777215, 16777216, 4294967295,
        1099511627775, 1099511627776, 281474976710655, 281474976710656,
        72057594037927935, 72057594037927936, ulong.MaxValue
    };

    [Test, TestCaseSource("UInt32Cases")]
    public void WriteAndReadPackedUInt32(uint testValue)
    {
        writer.WritePackedUInt32(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadPackedUInt32(), "Writer and Reader have different values for packed 'uint' type");
    }

    [Test, TestCaseSource("UInt64Cases")]
    public void WriteAndReadPackedUInt64(ulong testValue)
    {
        writer.WritePackedUInt64(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadPackedUInt64(), "Writer and Reader have different values for packed 'ulong' type");
    }

    [Test, TestCaseSource("UInt32Cases")]
    public void WriteAndReadUInt32(uint testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadUInt32(), "Writer and Reader have different values for 'uint' type");
    }

    [Test, TestCaseSource("UInt64Cases")]
    public void WriteAndReadUInt64(ulong testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadUInt64(), "Writer and Reader have different values for 'ulong' type");
    }

    private static char[] CharCases = { char.MinValue, '\n', '\uFFF0', char.MaxValue };

    [Ignore("848212")]
    [Test, TestCaseSource("CharCases")]
    public void WriteAndReadChar(char testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadChar(), "Writer and Reader have different values for 'char' type");
    }

    private static byte[] ByteCases = { byte.MinValue, 127, byte.MaxValue };

    [Test, TestCaseSource("ByteCases")]
    public void WriteAndReadByte(byte testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadByte(), "Writer and Reader have different values for 'byte' type");
    }

    private static sbyte[] SByteCases = { sbyte.MinValue, 0, -0, +0, sbyte.MaxValue };

    [Test, TestCaseSource("SByteCases")]
    public void WriteAndReadSByte(sbyte testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadSByte(), "Writer and Reader have different values for 'sbyte' type");
    }

    private static short[] ShortCases =
    {
        short.MinValue, -127, 0, 128, 255, short.MaxValue
    };

    [Test, TestCaseSource("ShortCases")]
    public void WriteAndReadShort(short testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadInt16(), "Writer and Reader have different values for 'short' type");
    }

    private static ushort[] UshortCases =
    {
        ushort.MinValue, 128, 255, 32767, ushort.MaxValue
    };

    [Test, TestCaseSource("UshortCases")]
    public void WriteAndReadUShort(ushort testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadUInt16(), "Writer and Reader have different values for 'ushort' type");
    }

    private static int[] IntCases =
    {
        int.MinValue, -32768, -128, 0, 127, 255, 32767, int.MaxValue
    };

    [Test, TestCaseSource("IntCases")]
    public void WriteAndReadInt(int testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadInt32(), "Writer and Reader have different values for 'int' type");
    }

    private static long[] LongCases =
    {
        long.MinValue, -2147483648, -65536, -32768, -128, 0, 127, 255, 32767, 65535, 2147483647, long.MaxValue
    };

    [Test, TestCaseSource("LongCases")]
    public void WriteAndReadLong(long testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadInt64(), "Writer and Reader have different values for 'long' type");
    }

    private static float[] FloatCases =
    {
        float.MinValue, float.NaN, float.Epsilon, float.NegativeInfinity, float.PositiveInfinity, float.MaxValue
    };

    [Test, TestCaseSource("FloatCases")]
    public void WriteAndReadFloat(float testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadSingle(), "Writer and Reader have different values for 'float' type");
    }

    private static double[] DoubleCases =
    {
        double.MinValue, double.Epsilon, double.NaN, double.NegativeInfinity , double.PositiveInfinity, double.MaxValue,
        float.MinValue, float.NaN, float.Epsilon, float.NegativeInfinity, float.PositiveInfinity, float.MaxValue
    };

    [Test, TestCaseSource("DoubleCases")]
    public void WriteAndReadDouble(double testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadDouble(), "Writer and Reader have different values for 'double' type");
    }

    private static decimal[] DecimalCases =
    {
        decimal.MinValue, decimal.MinusOne, decimal.One, decimal.Zero, decimal.MaxValue
    };

    [Test, TestCaseSource("DecimalCases")]
    public void WriteAndReadDecimal(decimal testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadDecimal(), "Writer and Reader have different values for 'decimal' type");
    }

    private static bool[] BoolCases =
    {
        true, false
    };

    [Test, TestCaseSource("BoolCases")]
    public void WriteAndReadBool(bool testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadBoolean(), "Writer and Reader have different values for 'bool' type");
    }

    // Cases have been taken from http://www.cl.cam.ac.uk/~mgk25/ucs/examples/quickbrown.txt
    private static string[] StringCases =
    {
        bool.TrueString, bool.FalseString, string.Empty,
        "Quizdeltagerne spiste jordb??r med fl??de, mens cirkusklovnen Wolther spillede p?? xylofon.",
        "Falsches ??ben von Xylophonmusik qu??lt jeden gr????eren Zwerg",
        "???????????? ??????? ??????????????? ??????? ????? ??????? ??????? ??????? ??????????????? ????????????",
        "The quick brown fox jumps over the lazy dog",
        "El ping??ino Wenceslao hizo kil??metros bajo exhaustiva lluvia y fr??o, a??oraba a su querido cachorro.",
        "Le c??ur d????u mais l'??me plut??t na??ve, Lou??s r??va de crapa??ter en cano?? au del?? des ??les, pr??s du m??lstr??m o?? br??lent les nov??.",
        "D'fhuascail ??osa, ??rmhac na h??ighe Beannaithe, p??r ??ava agus ??dhaimh",
        "??rv??zt??r?? t??k??rf??r??g??p",
        "K??mi n?? ??xi h??r ykist ??j??fum n?? b????i v??l og ??drepa. S??v??r gr??t ????an ??v?? ??lpan var ??n??t",
        "????????????????????????????????????", "????????????????????? ??????????????? ?????????????????? ???????????????",
        "???? ???????? ???? ?????? ???????????? ?????????? ?????? ???? ???????? ?????? ????????????",
        "Pchn???? w t?? ????d?? je??a lub o??m skrzy?? fig",
        "?? ?????????? ?????? ?????? ???? ????????????? ????, ???? ?????????????????? ??????????????????!",
        "??? ?????????????????????????????????????????????????????????????????????????????????????????????", " Pijamal?? hasta, ya????z ??of??re ??abucak g??vendi."
    };

    [Test, TestCaseSource("StringCases")]
    public void WriteAndReadString(string testValue)
    {
        writer.Write(testValue);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(testValue, reader.ReadString(), "Writer and Reader have different values for 'string' type");
    }

    [Test]
    public void WriteNullString_ReadEmptyString()
    {
        string testString = null;
        writer.Write(testString);
        var reader = new NetworkReader(writer);
        Assert.AreEqual(string.Empty, reader.ReadString(), "Writer and Reader have different values for 'string' type");
    }
}
#pragma warning restore 618
