using UnityEngine;
using System.Collections;

public class UtilsConstanst {

	public static string VERTICAL = "VERTICAL"; 
	public static string HORIZONTAL = "HORIZONTAL"; 
	public static string DRAG_LEFT = "DRAG_LEFT"; 
	public static string DRAG_RIGHT = "DRAG_RIGHT"; 
	public static float SCENE_TRANSITION_TIME = 0.6f; 

	public static string API_GET_ALL_QUESTIONS = "http://camnangnguoilaixe.com/questions/public/api?cmd=get_questions"; 
	public static string API_GET_ALL_TOPICS = "http://camnangnguoilaixe.com/questions/public/api?cmd=get_all"; 

	public static string FAULT_1 = "" +
		"1. Không thắt dây an toàn, bị trừ 05 điểm;\n\n" +
		"2. Không bật đèn xi nhan trái khi xuất phát, bị trừ 05 điểm;\n\n" +
		"3. Không nhả hết phanh tay khi khởi hành, bị trừ 05 điểm;\n\n" +
		"4. Trong khoảng 15m không tăng từ số 1 lên số 3, bị trừ 05 điểm;\n\n" +
		"5. Quá 30 giây kể từ khi có lệnh xuất phát, không đi qua vạch xuất phát, bị truất quyền sát hạch;\n\n" +
		"6. Xe bị rung giật mạnh, bị trừ 05 điểm;\n\n7. Lái xe bị chết máy, mỗi lần bị trừ 05 điểm;\n\n" +
		"8. Để tốc độ động cơ quá 4000 vòng/phút, mỗi lần bị trừ 05 điểm;\n\n" +
		"9. Sử dụng từ tay số 3 trở lên khi tốc độ xe chạy dưới 30km/h, cứ 05 giây trừ 02 điểm;\n\n" +
		"10. Vi phạm quy tắc giao thông đường bộ, bị trừ 1 điểm;\n\n" +
		"11. Không thực hiện theo hiệu lệnh của sát hạch viên, bị truất quyền sát hạch;\n\n" +
		"12. Xử lý tình huống không hợp lý gây tai nạn, bị truất quyền sát hạch;\n\n" +
		"13. Khi tăng hoặc giảm số, xe bị choạng lái quá làn đường quy định, bị truất quyền sát hạch. ";

}

