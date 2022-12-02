using UnityEngine;

namespace BornCore.MirrorDev
{
    public class MyPlayerMovement : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 1;
        private Rigidbody rb;
        private Transform cam;
        private float speed = 5f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            cam = Camera.main.transform;
        }

        private void Update()
        {
            //Rotate
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");

            transform.position += new Vector3( x , 0, y) * speed * Time.deltaTime;
            

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.2f)
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            }
        }
    }
}