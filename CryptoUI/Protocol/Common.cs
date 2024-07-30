using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoUI.Protocol
{
    public unsafe class PtrVectorT
    {
        private List<ushort> offsets = new List<ushort>();
        private byte* baseptr = null;

        public int Count => offsets.Count;
        public ushort Length => (ushort)Count;

        public void SetBasePtr(byte* start)
        {
            baseptr = start;
        }
        public void Add(ushort offset)
        {
            offsets.Add(offset);
        }
        public void Add(int offset)
        {
            Add((ushort)offset);
        }
        public unsafe void Add(byte* elem)
        {
            Add((ushort)(elem - baseptr));
        }
        public unsafe byte* Get(int idx)
        {
            return baseptr + offsets[idx];
        }
        public unsafe byte* this[int key]
        {
            get => Get(key);
        }
        public void Clear()
        {
            offsets.Clear();
        }
    }
    public unsafe class UlongPtrT
    {
        public const ushort c_len = 8;
        private ulong* ptr;

        public UlongPtrT(ulong* ptr)
        {
            this.ptr = ptr;
        }

        public Nullable<ulong> Value
        {
            get
            {
                if (ptr == null)
                    return null;
                return *ptr;
            }
            set
            {
                if (value.HasValue)
                    *ptr = value.Value;
                else
                    *ptr = 0;
            }
        }
    }
    public class ProtocolUtilities
    {
        public static string writeable(char c)
        {
            if (c == 0)
                return string.Empty;
            return c.ToString();
        }
        public static string writeable(byte c)
        {
            if (c == 0)
                return string.Empty;
            return ((char)c).ToString();
        }
        public static string nanos_to_string(long v)
        {
            if (v == long.MaxValue)
                return "NaN";
            long whole = v / 1000000000L;
            ulong decimalv = ((ulong)Math.Abs(v)) - ((ulong)Math.Abs(whole)) * 1000000000UL;
            if (decimalv == 0)
                return whole.ToString();
            string outv = (v >= 0 || whole < 0) ? whole.ToString() + '.' : '-' + whole.ToString() + '.';
            char[] c = new char[10];
            for (int i = 0; i < 10; ++i)
                c[i] = '\0';
            c[0] = (char)((sbyte)(decimalv / 100000000UL) + 48);
            c[1] = (char)((sbyte)(((decimalv - ((ulong)(c[0] - 48) * 100000000UL))) / 10000000UL) + 48);
            c[2] = (char)((sbyte)(((decimalv - ((ulong)(c[0] - 48) * 100000000UL + (ulong)(c[1] - 48) * 10000000UL))) / 1000000UL) + 48);
            c[3] = (char)((sbyte)(((decimalv - ((ulong)(c[0] - 48) * 100000000UL + (ulong)(c[1] - 48) * 10000000UL + (ulong)(c[2] - 48) * 1000000UL))) / 100000UL) + 48);
            c[4] = (char)((sbyte)(((decimalv - ((ulong)(c[0] - 48) * 100000000UL + (ulong)(c[1] - 48) * 10000000UL + (ulong)(c[2] - 48) * 1000000UL + (ulong)(c[3] - 48) * 100000UL))) / 10000UL) + 48);
            c[5] = (char)((sbyte)(((decimalv - ((ulong)(c[0] - 48) * 100000000UL + (ulong)(c[1] - 48) * 10000000UL + (ulong)(c[2] - 48) * 1000000UL + (ulong)(c[3] - 48) * 100000UL + (ulong)(c[4] - 48) * 10000UL))) / 1000UL) + 48);
            c[6] = (char)((sbyte)(((decimalv - ((ulong)(c[0] - 48) * 100000000UL + (ulong)(c[1] - 48) * 10000000UL + (ulong)(c[2] - 48) * 1000000UL + (ulong)(c[3] - 48) * 100000UL + (ulong)(c[4] - 48) * 10000UL + (ulong)(c[5] - 48) * 1000UL))) / 100UL) + 48);
            c[7] = (char)((sbyte)(((decimalv - ((ulong)(c[0] - 48) * 100000000UL + (ulong)(c[1] - 48) * 10000000UL + (ulong)(c[2] - 48) * 1000000UL + (ulong)(c[3] - 48) * 100000UL + (ulong)(c[4] - 48) * 10000UL + (ulong)(c[5] - 48) * 1000UL + (ulong)(c[6] - 48) * 100UL))) / 10UL) + 48);
            c[8] = (char)((sbyte)(((decimalv - ((ulong)(c[0] - 48) * 100000000UL + (ulong)(c[1] - 48) * 10000000UL + (ulong)(c[2] - 48) * 1000000UL + (ulong)(c[3] - 48) * 100000UL + (ulong)(c[4] - 48) * 10000UL + (ulong)(c[5] - 48) * 1000UL + (ulong)(c[6] - 48) * 100UL + (ulong)(c[7] - 48) * 10UL)))) + 48);
            if (c[8] == '0')
                c[8] = '\0';
            if (c[7] == '0' && c[8] == '\0')
                c[7] = '\0';
            if (c[6] == '0' && c[8] == '\0' && c[7] == '\0')
                c[6] = '\0';
            if (c[5] == '0' && c[8] == '\0' && c[7] == '\0' && c[6] == '\0')
                c[5] = '\0';
            if (c[4] == '0' && c[8] == '\0' && c[7] == '\0' && c[6] == '\0' && c[5] == '\0')
                c[4] = '\0';
            if (c[3] == '0' && c[8] == '\0' && c[7] == '\0' && c[6] == '\0' && c[5] == '\0' && c[4] == '\0')
                c[3] = '\0';
            if (c[2] == '0' && c[8] == '\0' && c[7] == '\0' && c[6] == '\0' && c[5] == '\0' && c[4] == '\0' && c[3] == '\0')
                c[2] = '\0';
            if (c[1] == '0' && c[8] == '\0' && c[7] == '\0' && c[6] == '\0' && c[5] == '\0' && c[4] == '\0' && c[3] == '\0' && c[2] == '\0')
                c[1] = '\0';
            if (c[0] == '0' && c[8] == '\0' && c[7] == '\0' && c[6] == '\0' && c[5] == '\0' && c[4] == '\0' && c[3] == '\0' && c[2] == '\0' && c[1] == '\0')
                c[0] = '\0';
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < c.Length; ++i)
            {
                if (c[i] != 0)
                    sb.Append(c[i]);
                else
                    break;
            }
            outv += sb.ToString();
            return outv;
        }
    }

    public struct Str128T
    {
        private char c1;
        private char c2;
        private char c3;
        private char c4;
        private char c5;
        private char c6;
        private char c7;
        private char c8;
        private char c9;
        private char c10;
        private char c11;
        private char c12;
        private char c13;
        private char c14;
        private char c15;
        private char c16;
        private char c17;
        private char c18;
        private char c19;
        private char c20;
        private char c21;
        private char c22;
        private char c23;
        private char c24;
        private char c25;
        private char c26;
        private char c27;
        private char c28;
        private char c29;
        private char c30;
        private char c31;
        private char c32;
        private char c33;
        private char c34;
        private char c35;
        private char c36;
        private char c37;
        private char c38;
        private char c39;
        private char c40;
        private char c41;
        private char c42;
        private char c43;
        private char c44;
        private char c45;
        private char c46;
        private char c47;
        private char c48;
        private char c49;
        private char c50;
        private char c51;
        private char c52;
        private char c53;
        private char c54;
        private char c55;
        private char c56;
        private char c57;
        private char c58;
        private char c59;
        private char c60;
        private char c61;
        private char c62;
        private char c63;
        private char c64;
        private char c65;
        private char c66;
        private char c67;
        private char c68;
        private char c69;
        private char c70;
        private char c71;
        private char c72;
        private char c73;
        private char c74;
        private char c75;
        private char c76;
        private char c77;
        private char c78;
        private char c79;
        private char c80;
        private char c81;
        private char c82;
        private char c83;
        private char c84;
        private char c85;
        private char c86;
        private char c87;
        private char c88;
        private char c89;
        private char c90;
        private char c91;
        private char c92;
        private char c93;
        private char c94;
        private char c95;
        private char c96;
        private char c97;
        private char c98;
        private char c99;
        private char c100;
        private char c101;
        private char c102;
        private char c103;
        private char c104;
        private char c105;
        private char c106;
        private char c107;
        private char c108;
        private char c109;
        private char c110;
        private char c111;
        private char c112;
        private char c113;
        private char c114;
        private char c115;
        private char c116;
        private char c117;
        private char c118;
        private char c119;
        private char c120;
        private char c121;
        private char c122;
        private char c123;
        private char c124;
        private char c125;
        private char c126;
        private char c127;
        private char c128;

        private static string writeable(char c)
        {
            if (c == 0)
                return string.Empty;
            return c.ToString();
        }
        public string Value
        {
            get
            {
                return string.Empty + writeable(c1) + writeable(c2) + writeable(c3) + writeable(c4) + writeable(c5) + writeable(c6) + writeable(c7) + writeable(c8) + writeable(c9) + writeable(c10) + writeable(c11) + writeable(c12) + writeable(c13) + writeable(c14) + writeable(c15) + writeable(c16) + writeable(c17) + writeable(c18) + writeable(c19) + writeable(c20) + writeable(c21) + writeable(c22) + writeable(c23) + writeable(c24) + writeable(c25) + writeable(c26) + writeable(c27) + writeable(c28) + writeable(c29) + writeable(c30) + writeable(c31) + writeable(c32) + writeable(c33) + writeable(c34) + writeable(c35) + writeable(c36) + writeable(c37) + writeable(c38) + writeable(c39) + writeable(c40) + writeable(c41) + writeable(c42) + writeable(c43) + writeable(c44) + writeable(c45) + writeable(c46) + writeable(c47) + writeable(c48) + writeable(c49) + writeable(c50) + writeable(c51) + writeable(c52) + writeable(c53) + writeable(c54) + writeable(c55) + writeable(c56) + writeable(c57) + writeable(c58) + writeable(c59) + writeable(c60) + writeable(c61) + writeable(c62) + writeable(c63) + writeable(c64) + writeable(c65) + writeable(c66) + writeable(c67) + writeable(c68) + writeable(c69) + writeable(c70) + writeable(c71) + writeable(c72) + writeable(c73) + writeable(c74) + writeable(c75) + writeable(c76) + writeable(c77) + writeable(c78) + writeable(c79) + writeable(c80) + writeable(c81) + writeable(c82) + writeable(c83) + writeable(c84) + writeable(c85) + writeable(c86) + writeable(c87) + writeable(c88) + writeable(c89) + writeable(c90) + writeable(c91) + writeable(c92) + writeable(c93) + writeable(c94) + writeable(c95) + writeable(c96) + writeable(c97) + writeable(c98) + writeable(c99) + writeable(c100) + writeable(c101) + writeable(c102) + writeable(c103) + writeable(c104) + writeable(c105) + writeable(c106) + writeable(c107) + writeable(c108) + writeable(c109) + writeable(c110) + writeable(c111) + writeable(c112) + writeable(c113) + writeable(c114) + writeable(c115) + writeable(c116) + writeable(c117) + writeable(c118) + writeable(c119) + writeable(c120) + writeable(c121) + writeable(c122) + writeable(c123) + writeable(c124) + writeable(c125) + writeable(c126) + writeable(c127) + writeable(c128);
            }
            set
            {
                for (int i = 1; i <= value.Length; ++i)
                {
                    switch (i)
                    {
                        case 1:
                            {
                                c1 = value[i];
                            }
                            break;
                        case 2:
                            {
                                c2 = value[i];
                            }
                            break;
                        case 3:
                            {
                                c3 = value[i];
                            }
                            break;
                        case 4:
                            {
                                c4 = value[i];
                            }
                            break;
                        case 5:
                            {
                                c5 = value[i];
                            }
                            break;
                        case 6:
                            {
                                c6 = value[i];
                            }
                            break;
                        case 7:
                            {
                                c7 = value[i];
                            }
                            break;
                        case 8:
                            {
                                c8 = value[i];
                            }
                            break;
                        case 9:
                            {
                                c9 = value[i];
                            }
                            break;
                        case 10:
                            {
                                c10 = value[i];
                            }
                            break;
                        case 11:
                            {
                                c11 = value[i];
                            }
                            break;
                        case 12:
                            {
                                c12 = value[i];
                            }
                            break;
                        case 13:
                            {
                                c13 = value[i];
                            }
                            break;
                        case 14:
                            {
                                c14 = value[i];
                            }
                            break;
                        case 15:
                            {
                                c15 = value[i];
                            }
                            break;
                        case 16:
                            {
                                c16 = value[i];
                            }
                            break;
                        case 17:
                            {
                                c17 = value[i];
                            }
                            break;
                        case 18:
                            {
                                c18 = value[i];
                            }
                            break;
                        case 19:
                            {
                                c19 = value[i];
                            }
                            break;
                        case 20:
                            {
                                c20 = value[i];
                            }
                            break;
                        case 21:
                            {
                                c21 = value[i];
                            }
                            break;
                        case 22:
                            {
                                c22 = value[i];
                            }
                            break;
                        case 23:
                            {
                                c23 = value[i];
                            }
                            break;
                        case 24:
                            {
                                c24 = value[i];
                            }
                            break;
                        case 25:
                            {
                                c25 = value[i];
                            }
                            break;
                        case 26:
                            {
                                c26 = value[i];
                            }
                            break;
                        case 27:
                            {
                                c27 = value[i];
                            }
                            break;
                        case 28:
                            {
                                c28 = value[i];
                            }
                            break;
                        case 29:
                            {
                                c29 = value[i];
                            }
                            break;
                        case 30:
                            {
                                c30 = value[i];
                            }
                            break;
                        case 31:
                            {
                                c31 = value[i];
                            }
                            break;
                        case 32:
                            {
                                c32 = value[i];
                            }
                            break;
                        case 33:
                            {
                                c33 = value[i];
                            }
                            break;
                        case 34:
                            {
                                c34 = value[i];
                            }
                            break;
                        case 35:
                            {
                                c35 = value[i];
                            }
                            break;
                        case 36:
                            {
                                c36 = value[i];
                            }
                            break;
                        case 37:
                            {
                                c37 = value[i];
                            }
                            break;
                        case 38:
                            {
                                c38 = value[i];
                            }
                            break;
                        case 39:
                            {
                                c39 = value[i];
                            }
                            break;
                        case 40:
                            {
                                c40 = value[i];
                            }
                            break;
                        case 41:
                            {
                                c41 = value[i];
                            }
                            break;
                        case 42:
                            {
                                c42 = value[i];
                            }
                            break;
                        case 43:
                            {
                                c43 = value[i];
                            }
                            break;
                        case 44:
                            {
                                c44 = value[i];
                            }
                            break;
                        case 45:
                            {
                                c45 = value[i];
                            }
                            break;
                        case 46:
                            {
                                c46 = value[i];
                            }
                            break;
                        case 47:
                            {
                                c47 = value[i];
                            }
                            break;
                        case 48:
                            {
                                c48 = value[i];
                            }
                            break;
                        case 49:
                            {
                                c49 = value[i];
                            }
                            break;
                        case 50:
                            {
                                c50 = value[i];
                            }
                            break;
                        case 51:
                            {
                                c51 = value[i];
                            }
                            break;
                        case 52:
                            {
                                c52 = value[i];
                            }
                            break;
                        case 53:
                            {
                                c53 = value[i];
                            }
                            break;
                        case 54:
                            {
                                c54 = value[i];
                            }
                            break;
                        case 55:
                            {
                                c55 = value[i];
                            }
                            break;
                        case 56:
                            {
                                c56 = value[i];
                            }
                            break;
                        case 57:
                            {
                                c57 = value[i];
                            }
                            break;
                        case 58:
                            {
                                c58 = value[i];
                            }
                            break;
                        case 59:
                            {
                                c59 = value[i];
                            }
                            break;
                        case 60:
                            {
                                c60 = value[i];
                            }
                            break;
                        case 61:
                            {
                                c61 = value[i];
                            }
                            break;
                        case 62:
                            {
                                c62 = value[i];
                            }
                            break;
                        case 63:
                            {
                                c63 = value[i];
                            }
                            break;
                        case 64:
                            {
                                c64 = value[i];
                            }
                            break;
                        case 65:
                            {
                                c65 = value[i];
                            }
                            break;
                        case 66:
                            {
                                c66 = value[i];
                            }
                            break;
                        case 67:
                            {
                                c67 = value[i];
                            }
                            break;
                        case 68:
                            {
                                c68 = value[i];
                            }
                            break;
                        case 69:
                            {
                                c69 = value[i];
                            }
                            break;
                        case 70:
                            {
                                c70 = value[i];
                            }
                            break;
                        case 71:
                            {
                                c71 = value[i];
                            }
                            break;
                        case 72:
                            {
                                c72 = value[i];
                            }
                            break;
                        case 73:
                            {
                                c73 = value[i];
                            }
                            break;
                        case 74:
                            {
                                c74 = value[i];
                            }
                            break;
                        case 75:
                            {
                                c75 = value[i];
                            }
                            break;
                        case 76:
                            {
                                c76 = value[i];
                            }
                            break;
                        case 77:
                            {
                                c77 = value[i];
                            }
                            break;
                        case 78:
                            {
                                c78 = value[i];
                            }
                            break;
                        case 79:
                            {
                                c79 = value[i];
                            }
                            break;
                        case 80:
                            {
                                c80 = value[i];
                            }
                            break;
                        case 81:
                            {
                                c81 = value[i];
                            }
                            break;
                        case 82:
                            {
                                c82 = value[i];
                            }
                            break;
                        case 83:
                            {
                                c83 = value[i];
                            }
                            break;
                        case 84:
                            {
                                c84 = value[i];
                            }
                            break;
                        case 85:
                            {
                                c85 = value[i];
                            }
                            break;
                        case 86:
                            {
                                c86 = value[i];
                            }
                            break;
                        case 87:
                            {
                                c87 = value[i];
                            }
                            break;
                        case 88:
                            {
                                c88 = value[i];
                            }
                            break;
                        case 89:
                            {
                                c89 = value[i];
                            }
                            break;
                        case 90:
                            {
                                c90 = value[i];
                            }
                            break;
                        case 91:
                            {
                                c91 = value[i];
                            }
                            break;
                        case 92:
                            {
                                c92 = value[i];
                            }
                            break;
                        case 93:
                            {
                                c93 = value[i];
                            }
                            break;
                        case 94:
                            {
                                c94 = value[i];
                            }
                            break;
                        case 95:
                            {
                                c95 = value[i];
                            }
                            break;
                        case 96:
                            {
                                c96 = value[i];
                            }
                            break;
                        case 97:
                            {
                                c97 = value[i];
                            }
                            break;
                        case 98:
                            {
                                c98 = value[i];
                            }
                            break;
                        case 99:
                            {
                                c99 = value[i];
                            }
                            break;
                        case 100:
                            {
                                c100 = value[i];
                            }
                            break;
                        case 101:
                            {
                                c101 = value[i];
                            }
                            break;
                        case 102:
                            {
                                c102 = value[i];
                            }
                            break;
                        case 103:
                            {
                                c103 = value[i];
                            }
                            break;
                        case 104:
                            {
                                c104 = value[i];
                            }
                            break;
                        case 105:
                            {
                                c105 = value[i];
                            }
                            break;
                        case 106:
                            {
                                c106 = value[i];
                            }
                            break;
                        case 107:
                            {
                                c107 = value[i];
                            }
                            break;
                        case 108:
                            {
                                c108 = value[i];
                            }
                            break;
                        case 109:
                            {
                                c109 = value[i];
                            }
                            break;
                        case 110:
                            {
                                c110 = value[i];
                            }
                            break;
                        case 111:
                            {
                                c111 = value[i];
                            }
                            break;
                        case 112:
                            {
                                c112 = value[i];
                            }
                            break;
                        case 113:
                            {
                                c113 = value[i];
                            }
                            break;
                        case 114:
                            {
                                c114 = value[i];
                            }
                            break;
                        case 115:
                            {
                                c115 = value[i];
                            }
                            break;
                        case 116:
                            {
                                c116 = value[i];
                            }
                            break;
                        case 117:
                            {
                                c117 = value[i];
                            }
                            break;
                        case 118:
                            {
                                c118 = value[i];
                            }
                            break;
                        case 119:
                            {
                                c119 = value[i];
                            }
                            break;
                        case 120:
                            {
                                c120 = value[i];
                            }
                            break;
                        case 121:
                            {
                                c121 = value[i];
                            }
                            break;
                        case 122:
                            {
                                c122 = value[i];
                            }
                            break;
                        case 123:
                            {
                                c123 = value[i];
                            }
                            break;
                        case 124:
                            {
                                c124 = value[i];
                            }
                            break;
                        case 125:
                            {
                                c125 = value[i];
                            }
                            break;
                        case 126:
                            {
                                c126 = value[i];
                            }
                            break;
                        case 127:
                            {
                                c127 = value[i];
                            }
                            break;
                        case 128:
                            {
                                c128 = value[i];
                            }
                            break;
                        default:
                            break;
                    }
                }
                for (int i = value.Length + 1; i <= 128; ++i)
                {
                    switch (i)
                    {
                        case 1:
                            {
                                c1 = '\0';
                            }
                            break;
                        case 2:
                            {
                                c2 = '\0';
                            }
                            break;
                        case 3:
                            {
                                c3 = '\0';
                            }
                            break;
                        case 4:
                            {
                                c4 = '\0';
                            }
                            break;
                        case 5:
                            {
                                c5 = '\0';
                            }
                            break;
                        case 6:
                            {
                                c6 = '\0';
                            }
                            break;
                        case 7:
                            {
                                c7 = '\0';
                            }
                            break;
                        case 8:
                            {
                                c8 = '\0';
                            }
                            break;
                        case 9:
                            {
                                c9 = '\0';
                            }
                            break;
                        case 10:
                            {
                                c10 = '\0';
                            }
                            break;
                        case 11:
                            {
                                c11 = '\0';
                            }
                            break;
                        case 12:
                            {
                                c12 = '\0';
                            }
                            break;
                        case 13:
                            {
                                c13 = '\0';
                            }
                            break;
                        case 14:
                            {
                                c14 = '\0';
                            }
                            break;
                        case 15:
                            {
                                c15 = '\0';
                            }
                            break;
                        case 16:
                            {
                                c16 = '\0';
                            }
                            break;
                        case 17:
                            {
                                c17 = '\0';
                            }
                            break;
                        case 18:
                            {
                                c18 = '\0';
                            }
                            break;
                        case 19:
                            {
                                c19 = '\0';
                            }
                            break;
                        case 20:
                            {
                                c20 = '\0';
                            }
                            break;
                        case 21:
                            {
                                c21 = '\0';
                            }
                            break;
                        case 22:
                            {
                                c22 = '\0';
                            }
                            break;
                        case 23:
                            {
                                c23 = '\0';
                            }
                            break;
                        case 24:
                            {
                                c24 = '\0';
                            }
                            break;
                        case 25:
                            {
                                c25 = '\0';
                            }
                            break;
                        case 26:
                            {
                                c26 = '\0';
                            }
                            break;
                        case 27:
                            {
                                c27 = '\0';
                            }
                            break;
                        case 28:
                            {
                                c28 = '\0';
                            }
                            break;
                        case 29:
                            {
                                c29 = '\0';
                            }
                            break;
                        case 30:
                            {
                                c30 = '\0';
                            }
                            break;
                        case 31:
                            {
                                c31 = '\0';
                            }
                            break;
                        case 32:
                            {
                                c32 = '\0';
                            }
                            break;
                        case 33:
                            {
                                c33 = '\0';
                            }
                            break;
                        case 34:
                            {
                                c34 = '\0';
                            }
                            break;
                        case 35:
                            {
                                c35 = '\0';
                            }
                            break;
                        case 36:
                            {
                                c36 = '\0';
                            }
                            break;
                        case 37:
                            {
                                c37 = '\0';
                            }
                            break;
                        case 38:
                            {
                                c38 = '\0';
                            }
                            break;
                        case 39:
                            {
                                c39 = '\0';
                            }
                            break;
                        case 40:
                            {
                                c40 = '\0';
                            }
                            break;
                        case 41:
                            {
                                c41 = '\0';
                            }
                            break;
                        case 42:
                            {
                                c42 = '\0';
                            }
                            break;
                        case 43:
                            {
                                c43 = '\0';
                            }
                            break;
                        case 44:
                            {
                                c44 = '\0';
                            }
                            break;
                        case 45:
                            {
                                c45 = '\0';
                            }
                            break;
                        case 46:
                            {
                                c46 = '\0';
                            }
                            break;
                        case 47:
                            {
                                c47 = '\0';
                            }
                            break;
                        case 48:
                            {
                                c48 = '\0';
                            }
                            break;
                        case 49:
                            {
                                c49 = '\0';
                            }
                            break;
                        case 50:
                            {
                                c50 = '\0';
                            }
                            break;
                        case 51:
                            {
                                c51 = '\0';
                            }
                            break;
                        case 52:
                            {
                                c52 = '\0';
                            }
                            break;
                        case 53:
                            {
                                c53 = '\0';
                            }
                            break;
                        case 54:
                            {
                                c54 = '\0';
                            }
                            break;
                        case 55:
                            {
                                c55 = '\0';
                            }
                            break;
                        case 56:
                            {
                                c56 = '\0';
                            }
                            break;
                        case 57:
                            {
                                c57 = '\0';
                            }
                            break;
                        case 58:
                            {
                                c58 = '\0';
                            }
                            break;
                        case 59:
                            {
                                c59 = '\0';
                            }
                            break;
                        case 60:
                            {
                                c60 = '\0';
                            }
                            break;
                        case 61:
                            {
                                c61 = '\0';
                            }
                            break;
                        case 62:
                            {
                                c62 = '\0';
                            }
                            break;
                        case 63:
                            {
                                c63 = '\0';
                            }
                            break;
                        case 64:
                            {
                                c64 = '\0';
                            }
                            break;
                        case 65:
                            {
                                c65 = '\0';
                            }
                            break;
                        case 66:
                            {
                                c66 = '\0';
                            }
                            break;
                        case 67:
                            {
                                c67 = '\0';
                            }
                            break;
                        case 68:
                            {
                                c68 = '\0';
                            }
                            break;
                        case 69:
                            {
                                c69 = '\0';
                            }
                            break;
                        case 70:
                            {
                                c70 = '\0';
                            }
                            break;
                        case 71:
                            {
                                c71 = '\0';
                            }
                            break;
                        case 72:
                            {
                                c72 = '\0';
                            }
                            break;
                        case 73:
                            {
                                c73 = '\0';
                            }
                            break;
                        case 74:
                            {
                                c74 = '\0';
                            }
                            break;
                        case 75:
                            {
                                c75 = '\0';
                            }
                            break;
                        case 76:
                            {
                                c76 = '\0';
                            }
                            break;
                        case 77:
                            {
                                c77 = '\0';
                            }
                            break;
                        case 78:
                            {
                                c78 = '\0';
                            }
                            break;
                        case 79:
                            {
                                c79 = '\0';
                            }
                            break;
                        case 80:
                            {
                                c80 = '\0';
                            }
                            break;
                        case 81:
                            {
                                c81 = '\0';
                            }
                            break;
                        case 82:
                            {
                                c82 = '\0';
                            }
                            break;
                        case 83:
                            {
                                c83 = '\0';
                            }
                            break;
                        case 84:
                            {
                                c84 = '\0';
                            }
                            break;
                        case 85:
                            {
                                c85 = '\0';
                            }
                            break;
                        case 86:
                            {
                                c86 = '\0';
                            }
                            break;
                        case 87:
                            {
                                c87 = '\0';
                            }
                            break;
                        case 88:
                            {
                                c88 = '\0';
                            }
                            break;
                        case 89:
                            {
                                c89 = '\0';
                            }
                            break;
                        case 90:
                            {
                                c90 = '\0';
                            }
                            break;
                        case 91:
                            {
                                c91 = '\0';
                            }
                            break;
                        case 92:
                            {
                                c92 = '\0';
                            }
                            break;
                        case 93:
                            {
                                c93 = '\0';
                            }
                            break;
                        case 94:
                            {
                                c94 = '\0';
                            }
                            break;
                        case 95:
                            {
                                c95 = '\0';
                            }
                            break;
                        case 96:
                            {
                                c96 = '\0';
                            }
                            break;
                        case 97:
                            {
                                c97 = '\0';
                            }
                            break;
                        case 98:
                            {
                                c98 = '\0';
                            }
                            break;
                        case 99:
                            {
                                c99 = '\0';
                            }
                            break;
                        case 100:
                            {
                                c100 = '\0';
                            }
                            break;
                        case 101:
                            {
                                c101 = '\0';
                            }
                            break;
                        case 102:
                            {
                                c102 = '\0';
                            }
                            break;
                        case 103:
                            {
                                c103 = '\0';
                            }
                            break;
                        case 104:
                            {
                                c104 = '\0';
                            }
                            break;
                        case 105:
                            {
                                c105 = '\0';
                            }
                            break;
                        case 106:
                            {
                                c106 = '\0';
                            }
                            break;
                        case 107:
                            {
                                c107 = '\0';
                            }
                            break;
                        case 108:
                            {
                                c108 = '\0';
                            }
                            break;
                        case 109:
                            {
                                c109 = '\0';
                            }
                            break;
                        case 110:
                            {
                                c110 = '\0';
                            }
                            break;
                        case 111:
                            {
                                c111 = '\0';
                            }
                            break;
                        case 112:
                            {
                                c112 = '\0';
                            }
                            break;
                        case 113:
                            {
                                c113 = '\0';
                            }
                            break;
                        case 114:
                            {
                                c114 = '\0';
                            }
                            break;
                        case 115:
                            {
                                c115 = '\0';
                            }
                            break;
                        case 116:
                            {
                                c116 = '\0';
                            }
                            break;
                        case 117:
                            {
                                c117 = '\0';
                            }
                            break;
                        case 118:
                            {
                                c118 = '\0';
                            }
                            break;
                        case 119:
                            {
                                c119 = '\0';
                            }
                            break;
                        case 120:
                            {
                                c120 = '\0';
                            }
                            break;
                        case 121:
                            {
                                c121 = '\0';
                            }
                            break;
                        case 122:
                            {
                                c122 = '\0';
                            }
                            break;
                        case 123:
                            {
                                c123 = '\0';
                            }
                            break;
                        case 124:
                            {
                                c124 = '\0';
                            }
                            break;
                        case 125:
                            {
                                c125 = '\0';
                            }
                            break;
                        case 126:
                            {
                                c126 = '\0';
                            }
                            break;
                        case 127:
                            {
                                c127 = '\0';
                            }
                            break;
                        case 128:
                            {
                                c128 = '\0';
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}