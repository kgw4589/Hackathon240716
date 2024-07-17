using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    public GameObject image;
    
    [SerializeField]private float maxHp;
    private float _hp;

    private void Awake()
    {
        _hp = maxHp / 2;
    }

    private void Update()
    {
        _hpSlider.value = _hp / maxHp;
        
        var thisPos = image.transform.localPosition;
        image.transform.localPosition = new Vector3((_hpSlider.value * 1000) - 500, thisPos.y,thisPos.z);
    }

    public void Calculate(float count)
    {
        _hp -= count;
    }

}
