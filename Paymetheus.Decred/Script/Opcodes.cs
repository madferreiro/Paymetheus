﻿// Copyright (c) 2016 The btcsuite developers
// Copyright (c) 2016 The Decred developers
// Licensed under the ISC license.  See LICENSE file in the project root for full license information.

namespace Paymetheus.Decred.Script
{
    static class Opcodes
    {
        public enum Opcode : byte
        {
            Op0,
            OpFalse = Op0,
            OpData1,
            OpData2,
            OpData3,
            OpData4,
            OpData5,
            OpData6,
            OpData7,
            OpData8,
            OpData9,
            OpData10,
            OpData11,
            OpData12,
            OpData13,
            OpData14,
            OpData15,
            OpData16,
            OpData17,
            OpData18,
            OpData19,
            OpData20,
            OpData21,
            OpData22,
            OpData23,
            OpData24,
            OpData25,
            OpData26,
            OpData27,
            OpData28,
            OpData29,
            OpData30,
            OpData31,
            OpData32,
            OpData33,
            OpData34,
            OpData35,
            OpData36,
            OpData37,
            OpData38,
            OpData39,
            OpData40,
            OpData41,
            OpData42,
            OpData43,
            OpData44,
            OpData45,
            OpData46,
            OpData47,
            OpData48,
            OpData49,
            OpData50,
            OpData51,
            OpData52,
            OpData53,
            OpData54,
            OpData55,
            OpData56,
            OpData57,
            OpData58,
            OpData59,
            OpData60,
            OpData61,
            OpData62,
            OpData63,
            OpData64,
            OpData65,
            OpData66,
            OpData67,
            OpData68,
            OpData69,
            OpData70,
            OpData71,
            OpData72,
            OpData73,
            OpData74,
            OpData75,
            OpPushdata1,
            OpPushdata2,
            OpPushdata4,
            Op1Negate,
            OpReserved,
            Op1,
            OpTrue = Op1,
            Op2,
            Op3,
            Op4,
            Op5,
            Op6,
            Op7,
            Op8,
            Op9,
            Op10,
            Op11,
            Op12,
            Op13,
            Op14,
            Op15,
            Op16,
            OpNop,
            OpVer,
            OpIf,
            OpNotIf,
            OpVerIf,
            OpVerNotIf,
            OpElse,
            OpEndIf,
            OpVerify,
            OpReturn,
            OpToAltStack,
            OpFromAltStack,
            Op2Drop,
            Op2Dup,
            Op3Dup,
            Op2Over,
            Op2Rot,
            Op2Swap,
            OpIfDup,
            OpDepth,
            OpDrop,
            OpDup,
            OpNip,
            OpOver,
            OpPick,
            OpRoll,
            OpRot,
            OpSwap,
            OpTuck,
            OpCat,
            OpSubstr,
            OpLeft,
            OpRight,
            OpSize,
            OpInvert,
            OpAnd,
            OpOr,
            OpXor,
            OpEqual,
            OpEqualVerify,
            OpReserved1,
            OpReserved2,
            Op1Add,
            Op1Sub,
            Op2Mul,
            Op2Div,
            OpNegate,
            OpAbs,
            OpNot,
            Op0NotEqual,
            OpAdd,
            OpSub,
            OpMul,
            OpDiv,
            OpMod,
            OpLShift,
            OpRShift,
            OpBoolAnd,
            OpBoolOr,
            OpNumEqual,
            OpNumEqualVerify,
            OpNumNotEqual,
            OpLessThan,
            OpGreaterThan,
            OpLessThanOrEqual,
            OpGreaterThanOrEqual,
            OpMin,
            OpMax,
            OpWithin,
            OpRipemd160,
            OpSha1,
            OpSha256,
            OpHash160,
            OpHash256,
            OpCodeSeparator,
            OpChecksig,
            OpChecksigVerify,
            OpCheckMultisig,
            OpCheckMultisigVerify,
            OpNop1,
            OpNop2,
            OpNop3,
            OpNop4,
            OpNop5,
            OpNop6,
            OpNop7,
            OpNop8,
            OpNop9,
            OpNop10,
            OpSsTx,
            OpSsGen,
            OpSsRtx,
            OpSsTxChange,
            OpChecksigAlt,
            OpChecksigAltVerify,
            OpUnknown192,
            OpUnknown193,
            OpUnknown194,
            OpUnknown195,
            OpUnknown196,
            OpUnknown197,
            OpUnknown198,
            OpUnknown199,
            OpUnknown200,
            OpUnknown201,
            OpUnknown202,
            OpUnknown203,
            OpUnknown204,
            OpUnknown205,
            OpUnknown206,
            OpUnknown207,
            OpUnknown208,
            OpUnknown209,
            OpUnknown210,
            OpUnknown211,
            OpUnknown212,
            OpUnknown213,
            OpUnknown214,
            OpUnknown215,
            OpUnknown216,
            OpUnknown217,
            OpUnknown218,
            OpUnknown219,
            OpUnknown220,
            OpUnknown221,
            OpUnknown222,
            OpUnknown223,
            OpUnknown224,
            OpUnknown225,
            OpUnknown226,
            OpUnknown227,
            OpUnknown228,
            OpUnknown229,
            OpUnknown230,
            OpUnknown231,
            OpUnknown232,
            OpUnknown233,
            OpUnknown234,
            OpUnknown235,
            OpUnknown236,
            OpUnknown237,
            OpUnknown238,
            OpUnknown239,
            OpUnknown240,
            OpUnknown241,
            OpUnknown242,
            OpUnknown243,
            OpUnknown244,
            OpUnknown245,
            OpUnknown246,
            OpUnknown247,
            OpUnknown248,
            OpSmallData,
            OpSmallInteger,
            OpPubkeys,
            UpUnknown252,
            OpPubkeyHash,
            OpPubkey,
            OpInvalidOpcode,
        }
    }
}
