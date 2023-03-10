using ForroDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForroDotNetTests;

[TestClass]
public class ForroTests
{
    [TestMethod]
    [DataRow("6D696E68612076696461206520616E64617220706F7220657374652070616973", "6D6F7374726F2061", "C5A96C62F29352AFF26295B58DA0595C62108225F14E331116AD3F7B4EA000FEC0F0368E421149B26B0B4398DB7B3BBB99E3F5D7A91BF028996A8C4651707EF1DCBEE0C1271A0CF7E00EB1BC1E6FF86EF23CACA986A0037E02922BA5AA6A1D6DF09F5BD1C540B0D9D1CC8B3EC390660AE68A8849FB57EA3A71D844E720B48470")]
    [DataRow("657520766F75206D6F73747261722070726120766F63657320636F6D6F207365", "64616E6361206F20", "4B768C5C174BC9C1CE1B8C2B1FACE8E45A63F92E21D97B81C89D61900882D92773C5F7E62A1F297CEE9BAE88BB6C70477B803ACAE317C0184674EEFA434699B850B6A45ED97B3479852A76A6696A23769AAAC2D735FF73F28B9DFA8B2242B20B7C4E68C03D16226EE9066933598443DAF3BF437BBCBC9F04C7ECEFA6A24FAD3D")]
    public void TestVectors(string key, string nonce, string stream)
    {
        Span<byte> k = Convert.FromHexString(key);
        Span<byte> n = Convert.FromHexString(nonce);
        Span<byte> s = Convert.FromHexString(stream);
        Span<byte> p = new byte[s.Length];
        Span<byte> c = new byte[p.Length];
        
        Forro.Encrypt(c, p, n, k);
        
        Assert.IsTrue(c.SequenceEqual(s));
    }
}