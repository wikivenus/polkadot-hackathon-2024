//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Hydration.NetApi.Generated.Model.pallet_lbp
{
    
    
    /// <summary>
    /// >> 114 - Composite[pallet_lbp.Pool]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Pool : BaseType
    {
        
        /// <summary>
        /// >> owner
        /// </summary>
        public Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 Owner { get; set; }
        /// <summary>
        /// >> start
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32> Start { get; set; }
        /// <summary>
        /// >> end
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32> End { get; set; }
        /// <summary>
        /// >> assets
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> Assets { get; set; }
        /// <summary>
        /// >> initial_weight
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 InitialWeight { get; set; }
        /// <summary>
        /// >> final_weight
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 FinalWeight { get; set; }
        /// <summary>
        /// >> weight_curve
        /// </summary>
        public Hydration.NetApi.Generated.Model.pallet_lbp.EnumWeightCurveType WeightCurve { get; set; }
        /// <summary>
        /// >> fee
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> Fee { get; set; }
        /// <summary>
        /// >> fee_collector
        /// </summary>
        public Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 FeeCollector { get; set; }
        /// <summary>
        /// >> repay_target
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 RepayTarget { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Pool";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Owner.Encode());
            result.AddRange(Start.Encode());
            result.AddRange(End.Encode());
            result.AddRange(Assets.Encode());
            result.AddRange(InitialWeight.Encode());
            result.AddRange(FinalWeight.Encode());
            result.AddRange(WeightCurve.Encode());
            result.AddRange(Fee.Encode());
            result.AddRange(FeeCollector.Encode());
            result.AddRange(RepayTarget.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Owner = new Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Owner.Decode(byteArray, ref p);
            Start = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            Start.Decode(byteArray, ref p);
            End = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            End.Decode(byteArray, ref p);
            Assets = new Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>();
            Assets.Decode(byteArray, ref p);
            InitialWeight = new Substrate.NetApi.Model.Types.Primitive.U32();
            InitialWeight.Decode(byteArray, ref p);
            FinalWeight = new Substrate.NetApi.Model.Types.Primitive.U32();
            FinalWeight.Decode(byteArray, ref p);
            WeightCurve = new Hydration.NetApi.Generated.Model.pallet_lbp.EnumWeightCurveType();
            WeightCurve.Decode(byteArray, ref p);
            Fee = new Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>();
            Fee.Decode(byteArray, ref p);
            FeeCollector = new Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            FeeCollector.Decode(byteArray, ref p);
            RepayTarget = new Substrate.NetApi.Model.Types.Primitive.U128();
            RepayTarget.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}