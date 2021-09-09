using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class AudioParamsSO : ScriptableObject
{
    [Header("BGM音量:再生前に変更しないと反映されない")]
    [Range(0, 1)]
    public float BGMVolume;

    [Header("SEの音量の上限")]
    [Range(0, 1)]
    public float SEVolume;

    [Header("BGMの音量")]
    [Range(0, 1)]
    public float OPThemeVolume;
    [Range(0, 1)]
    public float FieldVolume;
    [Range(0, 1)]
    public float EndVolume;

    
    [Header("SEの音量")]
    [Range(0, 1)]
    public float UhoVolume;
    [Range(0, 1)]
    public float UkiVolume;
    [Range(0, 1)]
    public float DamageVolume;
    [Range(0, 1)]
    public float GameOverVolume;
    [Range(0, 1)]
    public float KnockOutVolume;
    [Range(0, 1)]
    public float BreakVolume;
    [Range(0, 1)]
    public float FeelGoodVolume;
    [Range(0, 1)]
    public float BooingVolume;
    [Range(0, 1)]
    public float WalkVolume;
    [Range(0, 1)]
    public float BikeVolume;
    [Range(0, 1)]
    public float BikeRunVolume;
    [Range(0, 1)]
    public float DanceVolume;

    public float GetVolume(SoundManager.BGM bgm)
    {
        switch (bgm)
        {
            case SoundManager.BGM.OPTheme:
                return OPThemeVolume * BGMVolume;
            case SoundManager.BGM.Field:
                return FieldVolume * BGMVolume;
            case SoundManager.BGM.End:
                return EndVolume * BGMVolume;



        }
        return 0;
    }


    public float GetVolume(SoundManager.SE se)
    {
        switch (se)
        {
            case SoundManager.SE.Uho:
                return UhoVolume * SEVolume;
            case SoundManager.SE.Uki:
                return UkiVolume * SEVolume;
            case SoundManager.SE.Damage:
                return DamageVolume * SEVolume;
            case SoundManager.SE.GameOver:
                return GameOverVolume * SEVolume;
            case SoundManager.SE.KnockOut:
                return KnockOutVolume * SEVolume;
            case SoundManager.SE.Break:
                return BreakVolume * SEVolume;
            case SoundManager.SE.FeelGood:
                return FeelGoodVolume * SEVolume;
            case SoundManager.SE.Booing:
                return BooingVolume * SEVolume;
            case SoundManager.SE.Walk:
                return WalkVolume * SEVolume;
            case SoundManager.SE.Bike:
                return BikeVolume * SEVolume;
            case SoundManager.SE.BikeRun:
                return BikeRunVolume * SEVolume;
            case SoundManager.SE.Dance:
                return DanceVolume * SEVolume;

        }
        return 0;
    }

    public const string PATH = "AudioParamsSO";
    private static AudioParamsSO _entity;
    public static AudioParamsSO Entity
    {
        get
        {
            //初アクセス時にロードする
            if (_entity == null)
            {
                _entity = Resources.Load<AudioParamsSO>(PATH);

                //ロード出来なかった場合はエラーログを表示
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}
