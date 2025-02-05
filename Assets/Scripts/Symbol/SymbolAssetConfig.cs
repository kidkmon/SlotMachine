using UnityEngine;

[CreateAssetMenu]
public class SymbolAssetConfig : ScriptableObject
{
    [SerializeField] int _id;
    [SerializeField] int _payout;
    [SerializeField] Sprite _icon;
    [SerializeField] bool _isWild;
    
    public int Id => _id;
    public int Payout => _payout;
    public Sprite Icon => _icon;
    public bool IsWild => _isWild;
}