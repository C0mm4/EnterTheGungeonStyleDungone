# 📌 Enter the Gunegeon 스타일 랜덤 던전 메이커

## 1. 모듈 개요 (Overview)  
- **설명**: Enter the Gungeon 스타일의 랜덤한 던전 생성기.
- **지원 Unity 버전**: 2021.3 LTS 이상  
- **의존성**: TextMeshPro 설치 필요 (버튼 UI)

---

## 2. 적용 방법 (Usage / Setup)  
### GameObject Inspector 연결 방식  
1. Scene에 빈 GameObject 생성
2. 생성된 Object에 GameManager Component 추가
3. GameManager에서 자체적으로 던전 생성에 필요한 모듈을 포함하고 있어 따로 추가 연결은 불필요
4. 던전 방 구조 추가시 MapGen의 DungeonRoomGen() 메소드에서 해당 사이즈 타입에 맞는 Random GetMapNext의 Maximum Value 값 수정
  ex) size 1타입의 방 1개 추가 시 
     switch (size)
     {
         case 1:
             type = GameManager.Random.getMapNext(0, 13);  >> type = GameManager.Random.getMapNext(0, 14);
             break;
    }
   이 때 추가된 방의 prefab 파일명은 $"Dungeon/Room/Room{size.ToString()} {type.ToString()}" 으로 통일한다.
---

## 3. 주요 기능 (Features)  
- ✅ 랜덤 던전 생성 로직
    1. 시작 방을 중앙에 생성 후, 해당 방으로부터 일정 거리만큼 떨어진 영역에 생성 가능 구역을 추가
    2. 생성 가능한 영역에서 랜덤하게 하나를 선정
    3. 랜덤한 크기와 해당 크기의 랜덤한 방 index를 선정
    4. 선택된 위치에 선정된 방의 중앙좌표를 맞추고 해당 위치가 해당 방의 경계선에 닿도록 위치 설정
    5. 해당 위치에 이미 방이 생성된 영역이 있는지 확인, 이미 방이 생성된 영역이 포함되어 있으면 2번으로 돌아감
    6. 생성된 방과 해당 영역의 중점 방의을 저장, 해당 방에서 선정된 방향으로의 위치를 모두 제거하여 방이 겹치는 횟수를 줄임
    7. 생성된 방에 일정 거리만큼 떨어진 영역을 생성 가능 구역에 추가
    8. 모든 방 생성 후 연결된 방끼리 복도 연결
- ✅ Stage Level : 스테이지가 증가함에 따라 생성할 수 있는 방의 개수를 늘려 게임의 난이도를 점차 늘릴 수 있음
- ✅ Test Area :
    1. Gizmos를 활용해서 현재 방이 생성될 수 있는 영역을 시각화 함. (GameManager Object Selected)
    2. AddRoom 버튼을 눌러 해당 던전에서 방을 추가할 수 있으며 Gizmos도 갱신됨.

**데모**  
![demo](./Docs/demo.gif)  
던전을 생성하고, 다음 스테이지의 던전을 계속해서 생성하는 데모

![2025-09-14 18-39-59](https://github.com/user-attachments/assets/21fa035e-d509-4b3b-b5d5-c75bc0cefb9c)

Gizmos로 생성 가능한 영역을 시각화하고, AddRoom으로 던전에 방을 추가하는 데모

![2025-09-14 18-48-17](https://github.com/user-attachments/assets/4fd6ea97-662f-472f-be49-c36322306570)

---
