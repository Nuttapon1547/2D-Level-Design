using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    [Header("Door Settings")]
    public Transform door;             // ลากวัตถุประตูสีน้ำตาลมาใส่ช่องนี้
    public float openHeight = 3f;      // ระยะความสูงที่ประตูจะเลื่อนขึ้นไป
    public float openSpeed = 2f;       // ความเร็วในการเลื่อนเปิดประตู

    private bool isPlayerInRange = false;
    private bool isOpening = false;
    private Vector3 doorClosedPosition;
    private Vector3 doorOpenedPosition;

    void Start()
    {
        // บันทึกตำแหน่งเริ่มต้นของประตู และคำนวณตำแหน่งตอนเปิดสุดเอาไว้
        if (door != null)
        {
            doorClosedPosition = door.position;
            doorOpenedPosition = doorClosedPosition + new Vector3(0, openHeight, 0);
        }
    }

    void Update()
    {
        // ถ้าสถานะคือ isOpening ประตูจะค่อยๆ เลื่อนขึ้นไปจนกว่าจะถึงจุดที่กำหนด
        if (isOpening && door != null)
        {
            door.position = Vector3.MoveTowards(door.position, doorOpenedPosition, openSpeed * Time.deltaTime);
        }
    }

    // ฟังก์ชันนี้ทำงานเมื่อเอาเมาส์ไปคลิกที่ตัวปุ่ม (ต้องมี Collider)
    void OnMouseDown()
    {
        if (!isOpening)
        {
            Debug.Log("กดปุ่มสำเร็จ! ประตูกำลังเปิด");
            isOpening = true;

            // เปลี่ยนสีปุ่มเป็นสีเขียวเพื่อให้รู้ว่ากดติดแล้ว (Optional)
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}