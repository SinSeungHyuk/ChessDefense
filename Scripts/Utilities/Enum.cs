
// Only Enum

public enum EPool // 오브젝트 풀에 등록할 풀 종류
{
    SoundEffect,
    TowerPreview,
    Tower,
    Goblin,
    Hobgoblin,
    Troll,
    Wolf,
    BishopProjectile,
    RookProjectile,
    QueenProjectile,
}

public enum ETowerType
{
    Pawn,
    Knight,
    Bishop,
    Rook,
    Queen,
    King,
    None,
}

public enum ETowerStatType
{
    TowerDamage,
    TowerFireRate,
}

public enum ESoundEffectType
{
    GameEnd,
    MonsterHit,
    Dice,
    BuffTower,
    PawnAttack,
    KnightAttack,
    BishopAttack,
    RookAttack,
    QueenAttack,
}