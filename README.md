---

# Game 2D Top-Down

Một game 2D theo thể loại Top-Down, được phát triển bằng Unity. Được làm dựa trên một hướng dẫn YouTube.

---

## Mục lục

* [Giới thiệu](#giới-thiệu)
* [Tính năng](#tính-năng)
* [Hướng dẫn sử dụng / chơi](#hướng-dẫn-sử-dụng--chơi)
* [Yêu cầu hệ thống & công cụ](#yêu-cầu-hệ-thống--công-cụ)
* [Kiến trúc & cấu trúc dự án](#kiến-trúc--cấu-trúc-dự-án)
* [Nguồn cảm hứng / Tài nguyên sử dụng](#nguồn-cảm-hứng--tài-nguyên-sử-dụng)
* [Cài đặt & chạy](#cài-đặt--chạy)

---

## Giới thiệu

Game 2D Top-Down là một trò chơi nhỏ cho phép người chơi điều khiển nhân vật di chuyển trong môi trường nhìn từ trên xuống, tương tác với các vật thể, tránh chướng ngại vật, có thể thu thập hoặc đấu với kẻ địch (nếu có). Mục đích làm project này là để học cách:

* Tạo môi trường 2D trong Unity
* Di chuyển nhân vật theo input (WASD / mũi tên)
* Xử lý va chạm, ranh giới, vật cản
* Quản lý animation / sprite

---

## Tính năng

* Nhân vật có thể di chuyển trong các hướng (lên/xuống/trái/phải)
* Hệ thống va chạm: không đi xuyên qua tường hoặc vật cản
* Camera theo nhân vật 
* Giao diện đơn giản (nếu có HUD / điểm / máu)
* Âm thanh / hiệu ứng  

---

## Hướng dẫn sử dụng / chơi

1. Mở game (nếu chạy trên Web hoặc build exe)
2. Sử dụng các phím: **W, A, S, D** hoặc **các phím mũi tên** để di chuyển nhân vật
3. Tránh vật cản, có kẻ địch thu thập item tương tác theo cách được chỉ định
4. Mục tiêu: sống lâu nhất...

---

## Yêu cầu hệ thống & công cụ

* Unity phiên bản **6.0**  
* Trình duyệt web hỗ trợ WebGL  
---

## Kiến trúc & cấu trúc dự án

* `Assets/` — chứa tất cả các tài nguyên: sprites, âm thanh, script
* `Scenes/` — các scene (ví dụ: MainMenu, GameScene)
* `Scripts/` — các script điều khiển nhân vật, camera, va chạm
* `Prefabs/` — các prefab như nhân vật, vật cản, item
* `Animations/` — sprite sheet, animator controllers

---

## Nguồn cảm hứng & tài nguyên sử dụng

* Video hướng dẫn YouTube: *\[[Tên kênh](https://www.youtube.com/@lamgamedao)]*
* Sprites / đồ họa: *(nguồn miễn phí)*
* Âm thanh / effect: *(nguồn miễn phí)*
