﻿using Robust.Shared.Containers;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Shared.SS220.CryopodSSD;


/// <summary>
/// Component for In-game leaving or AFK
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed class CryopodSSDComponent : Component
{
    /// <summary>
    /// Delay before climbing in cryopod
    /// </summary>
    [DataField("entryDelay")] public float EntryDelay = 6f;
    
    /// <summary>
    /// Time to afk before automatic cryostorage transfer
    /// </summary>
    [DataField("autoTransferToCryoDelay")] public float AutoTransferDelay = 900f;

    [ViewVariables(VVAccess.ReadWrite)] public TimeSpan CurrentEntityLyingInCryopodTime;

    [ViewVariables(VVAccess.ReadWrite)] public ContainerSlot BodyContainer = default!;

    [Serializable, NetSerializable]
    public enum CryopodSSDVisuals : byte
    {
        ContainsEntity
    }
}

/// <summary>
/// Raises when somebody transfers to cryo storage 
/// </summary>
public sealed class TransferredToCryoStorageEvent : HandledEntityEventArgs
{
    public EntityUid CryopodSSD { get; }
    public EntityUid EntityToTransfer { get; }

    public TransferredToCryoStorageEvent(EntityUid cryopodSsd, EntityUid entityToTransfer)
    {
        CryopodSSD = cryopodSsd;
        EntityToTransfer = entityToTransfer;
    }
}