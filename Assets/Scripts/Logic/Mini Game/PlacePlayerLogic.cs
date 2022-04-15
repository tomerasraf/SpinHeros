using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlacePlayerLogic : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] PlayerData[] _playersData;

    public void CalculatePlayerPlace_EventCaller()
    {
        // CalculatePlayerPlace();
    }

    private void CalculatePlayerPlace()
    {
        for (int i = 0; i < _playersData.Length; i++)
        {
            if (i != 0)
            {
                if (_playersData[0].score > _playersData[i].score)
                {
                    _playersData[0].playerPlace--;
                }
                else
                {
                    _playersData[0].playerPlace++;
                }
            }

            if (i != 1)
            {
                if (_playersData[1].score > _playersData[i].score)
                {
                    _playersData[1].playerPlace--;
                }
                else
                {
                    _playersData[1].playerPlace++;
                }
            }

            if (i != 2)
            {
                if (_playersData[2].score > _playersData[i].score)
                {
                    _playersData[2].playerPlace--;
                }
                else
                {
                    _playersData[2].playerPlace++;
                }
            }

            if (i != 3)
            {
                if (_playersData[3].score > _playersData[i].score)
                {
                    _playersData[3].playerPlace--;
                }
                else
                {
                    _playersData[3].playerPlace++;
                }
            }
        }
    }
}