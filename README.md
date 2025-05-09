# Hackathon240716

## 개요  
본 프로젝트는 **역전 재판**을 오마주하여 3D로 구현한 프로젝트입니다.      
최근 우리 사회에서 **젠더갈등**이 발생, 심화되고 있습니다.        
갈등 속에서 구설에 오르는 여러 주장 및 상황들을, 사람들은 표면 상의 지표, 얕은 지식만 가지고, 현상이 발생한 이유나 자세한 내막 등은 모른채 사용합니다. 
이러한 문제를 해결하고자 게임 속 토론을 통해 **올바른 이유, 자세한 정보를 알리기 위해** 개발하였습니다.        


**장르**   
법정 배틀

**개발 인원**   
총원 4명 (프로그래밍 2명, 모델링 1명, 자료 수집 1명)

**개발 기간**   
2024.07.16. ~ 2024.07.18.

**참고자료**   
- 플레이 영상 : <https://url.kr/yjslfq>

---

## 개발 환경
| **용도** | **기술 스펙** | **선정 이유** |
|:---:|:---:|:---:|
| **게임 엔진** | **`Unity 3D 2022.3.17f1`**  | 해커톤의 짧은 시간, 간단한 게임 제작 용도로 적합.</br> 크로스 플랫폼, 다양한 기능 제공.</br> 22.3.X 버전이 대부분의 프로젝트에서 안정적. |
| **IDE** | `Jetbrains Rider` | 다양한 기능 제공, 학생 라이선스 무료.    |
| **저장소** | `Github, Github Desktop` | 사용 경험. 협업 용이.    다양한 기능 제공. 무료. |

---

## 주요 기능 및 사용 방법
**메인(시작) 화면**
* 게임 시작 버튼을 눌러 게임 씬으로 넘어갈 수 있음.

**다이얼로그**
* 대화창 방식의 UI를 사용하여 기본적으로 화자명, 대사를 띄움.
* 문장별 지정 딜레이 시간이 끝남 + 모든 대사가 출력됨의 조건을 만족할 때, 좌클릭으로 다음 문장을 실행함.     
![Image](https://github.com/user-attachments/assets/9959e80b-de56-4931-9724-d00530351dc4)      

* 중간중간 상대의 주장에 반론하는 선택지가 나옴. 3개의 선택지 버튼 중 하나를 눌러 분기점을 만듦.
* 선택지에 따라서 자료 UI가 팝업될 수 있음.
* 올바른 반론을 펼치는 선택 시 점수가 증가하며, 잘못된 반론을 펼치는 선택 시 점수가 감소함.      
![Image](https://github.com/user-attachments/assets/45f90aaa-d183-4f87-ac46-df8398550a29)

* 스토리의 내용은 Scriptable 오브젝트를 통해 관리함.
* 각각의 문장으로 나누어 사운드, 화자, 대사, 선택지 및 그에 대한 내용, 이미지, 애니메이션 등을 설정할 수 있음.
* 이렇게 만든 문장을 묶어 하나의 스토리 스크립터블이 탄생함.
* 선택지 혹은 하나의 스토리가 끝난 후 이어갈 다음 스토리를 지정할 수 있음.
![Image](https://github.com/user-attachments/assets/c90800a1-a574-4753-ac6c-4fc80cbb2cba)

**게임매니저**
* 게임의 시작, 종료를 진행함
* 플레이어의 선택지에 따라 점수의 증가, 감소를 처리함

**시네머신**
* 현재 화자에게 카메라 화면이 이동함
  
![Image](https://github.com/user-attachments/assets/9959e80b-de56-4931-9724-d00530351dc4)      

* 게임 종료 시 카메라가 정해진 경로를 따라 이동함

**점수 시스템**
* 점수가 증가, 감소할 때마다 상단의 점수 게이지가 증가, 감소함
  
![hackerton](https://github.com/user-attachments/assets/830a30eb-1d7d-417f-8ddd-a9eb02d08095)
* 게임 종료 시 점수에 따라 상승하는 이해도가 변경됨
---

## 라이선스
본 프로젝트는 단순 학습의 **비상업적 용도**로 제작되었습니다.

### 코드
- 본 프로젝트의 코드는 MIT 라이선스 하에 제공됩니다.

### 포함되지 않은 에셋
- `Assets/06.AssetStore` 폴더 내 모든 콘텐츠는 저작권 문제로 GitHub에 포함하지 않았습니다.
- 이 폴더는 Unity Asset Store에서 무료로 배포된 다음의 에셋을 포함하고 있습니다:
  - **Owen Memorial Hall**, [링크](https://assetstore.unity.com/packages/package/282519)
  - **Block People**, [링크](https://assetstore.unity.com/packages/3d/characters/block-people-60962)

> 위 에셋들은 Unity에서 정한 [Asset Store EULA](https://unity3d.com/legal/as_terms) 및 비재배포 조항에 따라 저장소에서 제외되었습니다. 단, 스크린샷 및 영상에는 등장할 수 있으며, 이는 Unity 측 라이선스에 위배되지 않습니다.
