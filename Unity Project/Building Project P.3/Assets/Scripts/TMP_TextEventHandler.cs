/*This script handles the recognizing of destination rooms from text read from the repository(i.e. Timetable).*/
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TMP_TextEventHandler : MonoBehaviour
{
    private TMP_Text textMeshPro;
    private Camera mainCamera;
    private GameObject player;
    private List<GameObject> waypoints;
    private GameObject panel;
    private string room;
    private int open = 0;
    private int teach = 0;


    public void Setup(GameObject playerObject, List<GameObject> waypointList, GameObject panelToHide, string roomToGo, int t)
    {
        player = playerObject;
        waypoints = waypointList;
        panel = panelToHide;
        room = roomToGo;
        teach = t;
        if (teach == 1)
        {
            open = 1;
        }
    }

    void Awake()
    {
        textMeshPro = GetComponent<TMP_Text>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || open == 1)
        {
            open = 0;
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, Input.mousePosition, mainCamera);
            if (linkIndex != -1 || teach == 1)
            {
                string clickedWord;
                if (teach == 0)
                {
                    TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];
                    clickedWord = linkInfo.GetLinkID(); // The word that was clicked
                }
                else
                {
                    clickedWord = room;
                }
                GameObject targetObject = player;

                //Auditorium SO
                if (clickedWord == "ΑΜΦ ΣΟ" || clickedWord == "ΑΜΦΣΟ" || clickedWord == "AMF SO" || clickedWord == "AMFSO")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - AMFSO");
                }

                //Auditorium A
                if (clickedWord == "ΑΜΦ Α" || clickedWord == "ΑΜΦΑ" || clickedWord == "AMF A" || clickedWord == "AMFA")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - AMFA");
                }

                //A101
                if (clickedWord == "Α.101" || clickedWord == "A.101" || clickedWord == "Α101" || clickedWord == "A101" || clickedWord == "Α-101" || clickedWord == "A-101")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A101");
                }

                //A103
                if (clickedWord == "Α.103" || clickedWord == "A.103" || clickedWord == "Α103" || clickedWord == "A103" || clickedWord == "Α-103" || clickedWord == "A-103")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A103");
                }

                //A105
                if (clickedWord == "Α.105" || clickedWord == "A.105" || clickedWord == "Α105" || clickedWord == "A105" || clickedWord == "Α-105" || clickedWord == "A-105")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A105");
                }

                //A107
                if (clickedWord == "Α.107" || clickedWord == "A.107" || clickedWord == "Α107" || clickedWord == "A107" || clickedWord == "Α-107" || clickedWord == "A-107")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A107");
                }

                //A109
                if (clickedWord == "Α.109" || clickedWord == "A.109" || clickedWord == "Α109" || clickedWord == "A109" || clickedWord == "Α-109" || clickedWord == "A-109")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A109");
                }

                //A111
                if (clickedWord == "Α.111" || clickedWord == "A.111" || clickedWord == "Α111" || clickedWord == "A111" || clickedWord == "Α-111" || clickedWord == "A-111")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A111");
                }

                //A113
                if (clickedWord == "Α.113" || clickedWord == "A.113" || clickedWord == "Α113" || clickedWord == "A113" || clickedWord == "Α-113" || clickedWord == "A-113")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A113");
                }

                //A115
                if (clickedWord == "Α.115" || clickedWord == "A.115" || clickedWord == "Α115" || clickedWord == "A115" || clickedWord == "Α-115" || clickedWord == "A-115")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A115");
                }

                //A117
                if (clickedWord == "Α.117" || clickedWord == "A.117" || clickedWord == "Α117" || clickedWord == "A117" || clickedWord == "Α-117" || clickedWord == "A-117")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A117");
                }

                //A119
                if (clickedWord == "Α.119" || clickedWord == "A.119" || clickedWord == "Α119" || clickedWord == "A119" || clickedWord == "Α-119" || clickedWord == "A-119")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A119");
                }

                //A121
                if (clickedWord == "Α.121" || clickedWord == "A.121" || clickedWord == "Α121" || clickedWord == "A121" || clickedWord == "Α-121" || clickedWord == "A-121")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A121");
                }

                //A123
                if (clickedWord == "Α.123" || clickedWord == "A.123" || clickedWord == "Α123" || clickedWord == "A123" || clickedWord == "Α-123" || clickedWord == "A-123")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A123");
                }

                //A125
                if (clickedWord == "Α.125" || clickedWord == "A.125" || clickedWord == "Α125" || clickedWord == "A125" || clickedWord == "Α-125" || clickedWord == "A-125")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - A125");
                }



                //B101
                if (clickedWord == "Β.101" || clickedWord == "B.101" || clickedWord == "Β101" || clickedWord == "B101" || clickedWord == "Β-101" || clickedWord == "B-101")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B101");
                }

                //B102
                if (clickedWord == "Β.102" || clickedWord == "B.102" || clickedWord == "Β102" || clickedWord == "B102" || clickedWord == "Β-102" || clickedWord == "B-102")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B102");
                }

                //B103
                if (clickedWord == "Β.103" || clickedWord == "B.103" || clickedWord == "Β103" || clickedWord == "B103" || clickedWord == "Β-103" || clickedWord == "B-103")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B103");
                }

                //B104
                if (clickedWord == "Β.104" || clickedWord == "B.104" || clickedWord == "Β104" || clickedWord == "B104" || clickedWord == "Β-104" || clickedWord == "B-104")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B104");
                }

                //B105
                if (clickedWord == "Β.105" || clickedWord == "B.105" || clickedWord == "Β105" || clickedWord == "B105" || clickedWord == "Β-105" || clickedWord == "B-105")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B105");
                }

                //B106
                if (clickedWord == "Β.106" || clickedWord == "B.106" || clickedWord == "Β106" || clickedWord == "B106" || clickedWord == "Β-106" || clickedWord == "B-106")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B106");
                }

                //B107
                if (clickedWord == "Β.107" || clickedWord == "B.107" || clickedWord == "Β107" || clickedWord == "B107" || clickedWord == "Β-107" || clickedWord == "B-107")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B107");
                }

                //B108
                if (clickedWord == "Β.108" || clickedWord == "B.108" || clickedWord == "Β108" || clickedWord == "B108" || clickedWord == "Β-108" || clickedWord == "B-108")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B108");
                }

                //B109
                if (clickedWord == "Β.109" || clickedWord == "B.109" || clickedWord == "Β109" || clickedWord == "B109" || clickedWord == "Β-109" || clickedWord == "B-109")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B109");
                }

                //B110
                if (clickedWord == "Β.110" || clickedWord == "B.110" || clickedWord == "Β110" || clickedWord == "B110" || clickedWord == "Β-110" || clickedWord == "B-110")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B110");
                }

                //B111
                if (clickedWord == "Β.111" || clickedWord == "B.111" || clickedWord == "Β111" || clickedWord == "B111" || clickedWord == "Β-111" || clickedWord == "B-111")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B111");
                }

                //B112
                if (clickedWord == "Β.112" || clickedWord == "B.112" || clickedWord == "Β112" || clickedWord == "B112" || clickedWord == "Β-112" || clickedWord == "B-112")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B112");
                }

                //B113
                if (clickedWord == "Β.113" || clickedWord == "B.113" || clickedWord == "Β113" || clickedWord == "B113" || clickedWord == "Β-113" || clickedWord == "B-113")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B113");
                }

                //B115
                if (clickedWord == "Β.115" || clickedWord == "B.115" || clickedWord == "Β115" || clickedWord == "B115" || clickedWord == "Β-115" || clickedWord == "B-115")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B115");
                }



                //E101
                if (clickedWord == "Ε.101" || clickedWord == "E.101" || clickedWord == "Ε101" || clickedWord == "E101" || clickedWord == "Ε-101" || clickedWord == "E-101")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E101");
                }

                //E102
                if (clickedWord == "Ε.102" || clickedWord == "E.102" || clickedWord == "Ε102" || clickedWord == "E102" || clickedWord == "Ε-102" || clickedWord == "E-102")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E102");
                }

                //E103
                if (clickedWord == "Ε.103" || clickedWord == "E.103" || clickedWord == "Ε103" || clickedWord == "E103" || clickedWord == "Ε-103" || clickedWord == "E-103")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E103");
                }

                //E104
                if (clickedWord == "Ε.104" || clickedWord == "E.104" || clickedWord == "Ε104" || clickedWord == "E104" || clickedWord == "Ε-104" || clickedWord == "E-104")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E104");
                }

                //E105
                if (clickedWord == "Ε.105" || clickedWord == "E.105" || clickedWord == "Ε105" || clickedWord == "E105" || clickedWord == "Ε-105" || clickedWord == "E-105")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E105");
                }

                //E106
                if (clickedWord == "Ε.106" || clickedWord == "E.106" || clickedWord == "Ε106" || clickedWord == "E106" || clickedWord == "Ε-106" || clickedWord == "E-106")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E106");
                }

                //E108
                if (clickedWord == "Ε.108" || clickedWord == "E.108" || clickedWord == "Ε108" || clickedWord == "E108" || clickedWord == "Ε-108" || clickedWord == "E-108")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E108");
                }

                //E110
                if (clickedWord == "Ε.110" || clickedWord == "E.110" || clickedWord == "Ε110" || clickedWord == "E110" || clickedWord == "Ε-110" || clickedWord == "E-110")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E110");
                }

                //E112
                if (clickedWord == "Ε.112" || clickedWord == "E.112" || clickedWord == "Ε112" || clickedWord == "E112" || clickedWord == "Ε-112" || clickedWord == "E-112")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E112");
                }


                //H101
                if (clickedWord == "Η.101" || clickedWord == "H.101" || clickedWord == "Η101" || clickedWord == "H101" || clickedWord == "Η-101" || clickedWord == "H-101")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H101");
                }

                //H102
                if (clickedWord == "Η.102" || clickedWord == "H.102" || clickedWord == "Η102" || clickedWord == "H102" || clickedWord == "Η-102" || clickedWord == "H-102")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H102");
                }

                //H103
                if (clickedWord == "Η.103" || clickedWord == "H.103" || clickedWord == "Η103" || clickedWord == "H103" || clickedWord == "Η-103" || clickedWord == "H-103")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H103");
                }

                //H104
                if (clickedWord == "Η.104" || clickedWord == "H.104" || clickedWord == "Η104" || clickedWord == "H104" || clickedWord == "Η-104" || clickedWord == "H-104")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H104");
                }

                //H105
                if (clickedWord == "Η.105" || clickedWord == "H.105" || clickedWord == "Η105" || clickedWord == "H105" || clickedWord == "Η-105" || clickedWord == "H-105")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H105");
                }

                //H106
                if (clickedWord == "Η.106" || clickedWord == "H.106" || clickedWord == "Η106" || clickedWord == "H106" || clickedWord == "Η-106" || clickedWord == "H-106")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H106");
                }

                //H107
                if (clickedWord == "Η.107" || clickedWord == "H.107" || clickedWord == "Η107" || clickedWord == "H107" || clickedWord == "Η-107" || clickedWord == "H-107")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H107");
                }

                //H108
                if (clickedWord == "Η.108" || clickedWord == "H.108" || clickedWord == "Η108" || clickedWord == "H108" || clickedWord == "Η-108" || clickedWord == "H-108")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H108");
                }

                //H110
                if (clickedWord == "Η.110" || clickedWord == "H.110" || clickedWord == "Η110" || clickedWord == "H110" || clickedWord == "Η-110" || clickedWord == "H-110")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H110");
                }

                //H112
                if (clickedWord == "Η.112" || clickedWord == "H.112" || clickedWord == "Η112" || clickedWord == "H112" || clickedWord == "Η-112" || clickedWord == "H-112")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H112");
                }

                //H114
                if (clickedWord == "Η.114" || clickedWord == "H.114" || clickedWord == "Η114" || clickedWord == "H114" || clickedWord == "Η-114" || clickedWord == "H-114")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H114");
                }




                //E201
                if (clickedWord == "Ε.201" || clickedWord == "E.201" || clickedWord == "Ε201" || clickedWord == "E201" || clickedWord == "Ε-201" || clickedWord == "E-201")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E201");
                }

                //E202
                if (clickedWord == "Ε.202" || clickedWord == "E.202" || clickedWord == "Ε202" || clickedWord == "E202" || clickedWord == "Ε-202" || clickedWord == "E-202")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E202");
                }

                //E203
                if (clickedWord == "Ε.203" || clickedWord == "E.203" || clickedWord == "Ε203" || clickedWord == "E203" || clickedWord == "Ε-203" || clickedWord == "E-203")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E203");
                }

                //E204
                if (clickedWord == "Ε.204" || clickedWord == "E.204" || clickedWord == "Ε204" || clickedWord == "E204" || clickedWord == "Ε-204" || clickedWord == "E-204")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E204");
                }

                //E205
                if (clickedWord == "Ε.205" || clickedWord == "E.205" || clickedWord == "Ε205" || clickedWord == "E205" || clickedWord == "Ε-205" || clickedWord == "E-205")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E205");
                }

                //E206
                if (clickedWord == "Ε.206" || clickedWord == "E.206" || clickedWord == "Ε206" || clickedWord == "E206" || clickedWord == "Ε-206" || clickedWord == "E-206")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E206");
                }

                //E207
                if (clickedWord == "Ε.207" || clickedWord == "E.207" || clickedWord == "Ε207" || clickedWord == "E207" || clickedWord == "Ε-207" || clickedWord == "E-207")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E207");
                }

                //E208
                if (clickedWord == "Ε.208" || clickedWord == "E.208" || clickedWord == "Ε208" || clickedWord == "E208" || clickedWord == "Ε-208" || clickedWord == "E-208")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E208");
                }

                //E210
                if (clickedWord == "Ε.210" || clickedWord == "E.210" || clickedWord == "Ε210" || clickedWord == "E210" || clickedWord == "Ε-210" || clickedWord == "E-210")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E210");
                }


                //H201
                if (clickedWord == "Η.201" || clickedWord == "H.201" || clickedWord == "Η201" || clickedWord == "H201" || clickedWord == "Η-201" || clickedWord == "H-201")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H201");
                }

                //H202
                if (clickedWord == "Η.202" || clickedWord == "H.202" || clickedWord == "Η202" || clickedWord == "H202" || clickedWord == "Η-202" || clickedWord == "H-202")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H202");
                }

                //H203
                if (clickedWord == "Η.203" || clickedWord == "H.203" || clickedWord == "Η203" || clickedWord == "H203" || clickedWord == "Η-203" || clickedWord == "H-203")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H203");
                }

                //H204
                if (clickedWord == "Η.204" || clickedWord == "H.204" || clickedWord == "Η204" || clickedWord == "H204" || clickedWord == "Η-204" || clickedWord == "H-204")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H204");
                }

                //H205
                if (clickedWord == "Η.205" || clickedWord == "H.205" || clickedWord == "Η205" || clickedWord == "H205" || clickedWord == "Η-205" || clickedWord == "H-205")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H205");
                }

                //H206
                if (clickedWord == "Η.206" || clickedWord == "H.206" || clickedWord == "Η206" || clickedWord == "H206" || clickedWord == "Η-206" || clickedWord == "H-206")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H206");
                }

                //H208
                if (clickedWord == "Η.208" || clickedWord == "H.208" || clickedWord == "Η208" || clickedWord == "H208" || clickedWord == "Η-208" || clickedWord == "H-208")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H208");
                }

                //H210
                if (clickedWord == "Η.210" || clickedWord == "H.210" || clickedWord == "Η210" || clickedWord == "H210" || clickedWord == "Η-210" || clickedWord == "H-210")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H210a");
                }

                //H212
                if (clickedWord == "Η.212" || clickedWord == "H.212" || clickedWord == "Η212" || clickedWord == "H212" || clickedWord == "Η-212" || clickedWord == "H-212")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H212");
                }

                //H214
                if (clickedWord == "Η.214" || clickedWord == "H.214" || clickedWord == "Η214" || clickedWord == "H214" || clickedWord == "Η-214" || clickedWord == "H-214")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H214");
                }

                //H216
                if (clickedWord == "Η.216" || clickedWord == "H.216" || clickedWord == "Η216" || clickedWord == "H216" || clickedWord == "Η-216" || clickedWord == "H-216")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H216");
                }


                //B201
                if (clickedWord == "Β.201" || clickedWord == "B.201" || clickedWord == "Β201" || clickedWord == "B201" || clickedWord == "Β-201" || clickedWord == "B-201")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B201");
                }

                //B202
                if (clickedWord == "Β.202" || clickedWord == "B.202" || clickedWord == "Β202" || clickedWord == "B202" || clickedWord == "Β-202" || clickedWord == "B-202")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B202");
                }

                //B203
                if (clickedWord == "Β.203" || clickedWord == "B.203" || clickedWord == "Β203" || clickedWord == "B203" || clickedWord == "Β-203" || clickedWord == "B-203")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B203");
                }

                //B204
                if (clickedWord == "Β.204" || clickedWord == "B.204" || clickedWord == "Β204" || clickedWord == "B204" || clickedWord == "Β-204" || clickedWord == "B-204")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B204");
                }

                //B205
                if (clickedWord == "Β.205" || clickedWord == "B.205" || clickedWord == "Β205" || clickedWord == "B205" || clickedWord == "Β-205" || clickedWord == "B-205")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B205");
                }

                //B206
                if (clickedWord == "Β.206" || clickedWord == "B.206" || clickedWord == "Β206" || clickedWord == "B206" || clickedWord == "Β-206" || clickedWord == "B-206")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B206");
                }

                //B207
                if (clickedWord == "Β.207" || clickedWord == "B.207" || clickedWord == "Β207" || clickedWord == "B207" || clickedWord == "Β-207" || clickedWord == "B-207")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B207");
                }

                //B208
                if (clickedWord == "Β.208" || clickedWord == "B.208" || clickedWord == "Β208" || clickedWord == "B208" || clickedWord == "Β-208" || clickedWord == "B-208")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B208");
                }

                //B209
                if (clickedWord == "Β.209" || clickedWord == "B.209" || clickedWord == "Β209" || clickedWord == "B209" || clickedWord == "Β-209" || clickedWord == "B-209")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B209");
                }

                //B210
                if (clickedWord == "Β.210" || clickedWord == "B.210" || clickedWord == "Β210" || clickedWord == "B210" || clickedWord == "Β-210" || clickedWord == "B-210")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B210");
                }

                //B211
                if (clickedWord == "Β.211" || clickedWord == "B.211" || clickedWord == "Β211" || clickedWord == "B211" || clickedWord == "Β-211" || clickedWord == "B-211")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B211");
                }

                //B212
                if (clickedWord == "Β.212" || clickedWord == "B.212" || clickedWord == "Β212" || clickedWord == "B212" || clickedWord == "Β-212" || clickedWord == "B-212")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B212");
                }

                //B213
                if (clickedWord == "Β.213" || clickedWord == "B.213" || clickedWord == "Β213" || clickedWord == "B213" || clickedWord == "Β-213" || clickedWord == "B-213")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B213");
                }

                //B214
                if (clickedWord == "Β.214" || clickedWord == "B.214" || clickedWord == "Β214" || clickedWord == "B214" || clickedWord == "Β-214" || clickedWord == "B-214")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B214");
                }

                //B215
                if (clickedWord == "Β.215" || clickedWord == "B.215" || clickedWord == "Β215" || clickedWord == "B215" || clickedWord == "Β-215" || clickedWord == "B-215")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B215");
                }

                //B217
                if (clickedWord == "Β.217" || clickedWord == "B.217" || clickedWord == "Β217" || clickedWord == "B217" || clickedWord == "Β-217" || clickedWord == "B-217")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B217");
                }

                //B219
                if (clickedWord == "Β.219" || clickedWord == "B.219" || clickedWord == "Β219" || clickedWord == "B219" || clickedWord == "Β-219" || clickedWord == "B-219")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B219");
                }

                //B221
                if (clickedWord == "Β.221" || clickedWord == "B.221" || clickedWord == "Β221" || clickedWord == "B221" || clickedWord == "Β-221" || clickedWord == "B-221")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B221");
                }

                //B223
                if (clickedWord == "Β.223" || clickedWord == "B.223" || clickedWord == "Β223" || clickedWord == "B223" || clickedWord == "Β-223" || clickedWord == "B-223")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B223");
                }

                //B225
                if (clickedWord == "Β.225" || clickedWord == "B.225" || clickedWord == "Β225" || clickedWord == "B225" || clickedWord == "Β-225" || clickedWord == "B-225")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B225");
                }

                //B227
                if (clickedWord == "Β.227" || clickedWord == "B.227" || clickedWord == "Β227" || clickedWord == "B227" || clickedWord == "Β-227" || clickedWord == "B-227")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B227");
                }

                //B229
                if (clickedWord == "Β.229" || clickedWord == "B.229" || clickedWord == "Β229" || clickedWord == "B229" || clickedWord == "Β-229" || clickedWord == "B-229")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B229");
                }




                //K201
                if (clickedWord == "Κ.201" || clickedWord == "K.201" || clickedWord == "Κ201" || clickedWord == "K201" || clickedWord == "Κ-201" || clickedWord == "K-201")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K201");
                }

                //K202
                if (clickedWord == "Κ.202" || clickedWord == "K.202" || clickedWord == "Κ202" || clickedWord == "K202" || clickedWord == "Κ-202" || clickedWord == "K-202")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K202");
                }

                //K203
                if (clickedWord == "Κ.203" || clickedWord == "K.203" || clickedWord == "Κ203" || clickedWord == "K203" || clickedWord == "Κ-203" || clickedWord == "K-203")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K203");
                }

                //K204
                if (clickedWord == "Κ.204" || clickedWord == "K.204" || clickedWord == "Κ204" || clickedWord == "K204" || clickedWord == "Κ-204" || clickedWord == "K-204")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K204");
                }

                //K205
                if (clickedWord == "Κ.205" || clickedWord == "K.205" || clickedWord == "Κ205" || clickedWord == "K205" || clickedWord == "Κ-205" || clickedWord == "K-205")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K205");
                }

                //K206
                if (clickedWord == "Κ.206" || clickedWord == "K.206" || clickedWord == "Κ206" || clickedWord == "K206" || clickedWord == "Κ-206" || clickedWord == "K-206")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K206");
                }

                //K207
                if (clickedWord == "Κ.207" || clickedWord == "K.207" || clickedWord == "Κ207" || clickedWord == "K207" || clickedWord == "Κ-207" || clickedWord == "K-207")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K207");
                }

                //K208
                if (clickedWord == "Κ.208" || clickedWord == "K.208" || clickedWord == "Κ208" || clickedWord == "K208" || clickedWord == "Κ-208" || clickedWord == "K-208")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K208");
                }

                //K209
                if (clickedWord == "Κ.209" || clickedWord == "K.209" || clickedWord == "Κ209" || clickedWord == "K209" || clickedWord == "Κ-209" || clickedWord == "K-209")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K209");
                }

                //K210
                if (clickedWord == "Κ.210" || clickedWord == "K.210" || clickedWord == "Κ210" || clickedWord == "K210" || clickedWord == "Κ-210" || clickedWord == "K-210")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K210");
                }

                //K211
                if (clickedWord == "Κ.211" || clickedWord == "K.211" || clickedWord == "Κ211" || clickedWord == "K211" || clickedWord == "Κ-211" || clickedWord == "K-211")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K211");
                }

                //K212
                if (clickedWord == "Κ.212" || clickedWord == "K.212" || clickedWord == "Κ212" || clickedWord == "K212" || clickedWord == "Κ-212" || clickedWord == "K-212")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K212");
                }

                //K213
                if (clickedWord == "Κ.213" || clickedWord == "K.213" || clickedWord == "Κ213" || clickedWord == "K213" || clickedWord == "Κ-213" || clickedWord == "K-213")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K213");
                }

                //K214
                if (clickedWord == "Κ.214" || clickedWord == "K.214" || clickedWord == "Κ214" || clickedWord == "K214" || clickedWord == "Κ-214" || clickedWord == "K-214")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K214");
                }

                //K215
                if (clickedWord == "Κ.215" || clickedWord == "K.215" || clickedWord == "Κ215" || clickedWord == "K215" || clickedWord == "Κ-215" || clickedWord == "K-215")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K215");
                }

                //K216
                if (clickedWord == "Κ.216" || clickedWord == "K.216" || clickedWord == "Κ216" || clickedWord == "K216" || clickedWord == "Κ-216" || clickedWord == "K-216")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K216");
                }

                //K217
                if (clickedWord == "Κ.217" || clickedWord == "K.217" || clickedWord == "Κ217" || clickedWord == "K217" || clickedWord == "Κ-217" || clickedWord == "K-217")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K217");
                }

                //K218
                if (clickedWord == "Κ.218" || clickedWord == "K.218" || clickedWord == "Κ218" || clickedWord == "K218" || clickedWord == "Κ-218" || clickedWord == "K-218")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K218");
                }

                //K219
                if (clickedWord == "Κ.219" || clickedWord == "K.219" || clickedWord == "Κ219" || clickedWord == "K219" || clickedWord == "Κ-219" || clickedWord == "K-219")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K219");
                }

                //K220
                if (clickedWord == "Κ.220" || clickedWord == "K.220" || clickedWord == "Κ220" || clickedWord == "K220" || clickedWord == "Κ-220" || clickedWord == "K-220")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K220");
                }

                //K221
                if (clickedWord == "Κ.221" || clickedWord == "K.221" || clickedWord == "Κ221" || clickedWord == "K221" || clickedWord == "Κ-221" || clickedWord == "K-221")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K221");
                }

                //K223
                if (clickedWord == "Κ.223" || clickedWord == "K.223" || clickedWord == "Κ223" || clickedWord == "K223" || clickedWord == "Κ-223" || clickedWord == "K-223")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K223");
                }

                //K225
                if (clickedWord == "Κ.225" || clickedWord == "K.225" || clickedWord == "Κ225" || clickedWord == "K225" || clickedWord == "Κ-225" || clickedWord == "K-225")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K225");
                }

                //K227
                if (clickedWord == "Κ.227" || clickedWord == "K.227" || clickedWord == "Κ227" || clickedWord == "K227" || clickedWord == "Κ-227" || clickedWord == "K-227")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K227");
                }



                //E301
                if (clickedWord == "Ε.301" || clickedWord == "E.301" || clickedWord == "Ε301" || clickedWord == "E301" || clickedWord == "Ε-301" || clickedWord == "E-301")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E301");
                }

                //E302
                if (clickedWord == "Ε.302" || clickedWord == "E.302" || clickedWord == "Ε302" || clickedWord == "E302" || clickedWord == "Ε-302" || clickedWord == "E-302")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E302");
                }

                //E303
                if (clickedWord == "Ε.303" || clickedWord == "E.303" || clickedWord == "Ε303" || clickedWord == "E303" || clickedWord == "Ε-303" || clickedWord == "E-303")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E303");
                }

                //E304
                if (clickedWord == "Ε.304" || clickedWord == "E.304" || clickedWord == "Ε304" || clickedWord == "E304" || clickedWord == "Ε-304" || clickedWord == "E-304")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E304");
                }

                //E305
                if (clickedWord == "Ε.305" || clickedWord == "E.305" || clickedWord == "Ε305" || clickedWord == "E305" || clickedWord == "Ε-305" || clickedWord == "E-305")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E305");
                }

                //E306
                if (clickedWord == "Ε.306" || clickedWord == "E.306" || clickedWord == "Ε306" || clickedWord == "E306" || clickedWord == "Ε-306" || clickedWord == "E-306")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E306");
                }

                //E307
                if (clickedWord == "Ε.307" || clickedWord == "E.307" || clickedWord == "Ε307" || clickedWord == "E307" || clickedWord == "Ε-307" || clickedWord == "E-307")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E307");
                }

                //E308
                if (clickedWord == "Ε.308" || clickedWord == "E.308" || clickedWord == "Ε308" || clickedWord == "E308" || clickedWord == "Ε-308" || clickedWord == "E-308")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E308");
                }

                //E309
                if (clickedWord == "Ε.309" || clickedWord == "E.309" || clickedWord == "Ε309" || clickedWord == "E309" || clickedWord == "Ε-309" || clickedWord == "E-309")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E309");
                }

                //E310
                if (clickedWord == "Ε.310" || clickedWord == "E.310" || clickedWord == "Ε310" || clickedWord == "E310" || clickedWord == "Ε-310" || clickedWord == "E-310")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E310");
                }

                //E311
                if (clickedWord == "Ε.311" || clickedWord == "E.311" || clickedWord == "Ε311" || clickedWord == "E311" || clickedWord == "Ε-311" || clickedWord == "E-311")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E311");
                }

                //E313
                if (clickedWord == "Ε.313" || clickedWord == "E.313" || clickedWord == "Ε313" || clickedWord == "E313" || clickedWord == "Ε-313" || clickedWord == "E-313")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E313");
                }

                //E315
                if (clickedWord == "Ε.315" || clickedWord == "E.315" || clickedWord == "Ε315" || clickedWord == "E315" || clickedWord == "Ε-315" || clickedWord == "E-315")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E315");
                }

                //E317
                if (clickedWord == "Ε.317" || clickedWord == "E.317" || clickedWord == "Ε317" || clickedWord == "E317" || clickedWord == "Ε-317" || clickedWord == "E-317")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - E317");
                }



                //H301
                if (clickedWord == "Η.301" || clickedWord == "H.301" || clickedWord == "Η301" || clickedWord == "H301" || clickedWord == "Η-301" || clickedWord == "H-301")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H301");
                }

                //H302
                if (clickedWord == "Η.302" || clickedWord == "H.302" || clickedWord == "Η302" || clickedWord == "H302" || clickedWord == "Η-302" || clickedWord == "H-302")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H302");
                }

                //H303
                if (clickedWord == "Η.303" || clickedWord == "H.303" || clickedWord == "Η303" || clickedWord == "H303" || clickedWord == "Η-303" || clickedWord == "H-303")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H303");
                }

                //H304
                if (clickedWord == "Η.304" || clickedWord == "H.304" || clickedWord == "Η304" || clickedWord == "H304" || clickedWord == "Η-304" || clickedWord == "H-304")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H304");
                }

                //H305
                if (clickedWord == "Η.305" || clickedWord == "H.305" || clickedWord == "Η305" || clickedWord == "H305" || clickedWord == "Η-305" || clickedWord == "H-305")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H305");
                }

                //H306
                if (clickedWord == "Η.306" || clickedWord == "H.306" || clickedWord == "Η306" || clickedWord == "H306" || clickedWord == "Η-306" || clickedWord == "H-306")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H306");
                }

                //H307
                if (clickedWord == "Η.307" || clickedWord == "H.307" || clickedWord == "Η307" || clickedWord == "H307" || clickedWord == "Η-307" || clickedWord == "H-307")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H307");
                }

                //H308
                if (clickedWord == "Η.308" || clickedWord == "H.308" || clickedWord == "Η308" || clickedWord == "H308" || clickedWord == "Η-308" || clickedWord == "H-308")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H308");
                }

                //H309
                if (clickedWord == "Η.309" || clickedWord == "H.309" || clickedWord == "Η309" || clickedWord == "H309" || clickedWord == "Η-309" || clickedWord == "H-309")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H309");
                }

                //H310
                if (clickedWord == "Η.310" || clickedWord == "H.310" || clickedWord == "Η310" || clickedWord == "H310" || clickedWord == "Η-310" || clickedWord == "H-310")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H310");
                }

                //H311
                if (clickedWord == "Η.311" || clickedWord == "H.311" || clickedWord == "Η311" || clickedWord == "H311" || clickedWord == "Η-311" || clickedWord == "H-311")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H311");
                }

                //H312
                if (clickedWord == "Η.312" || clickedWord == "H.312" || clickedWord == "Η312" || clickedWord == "H312" || clickedWord == "Η-312" || clickedWord == "H-312")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H312");
                }

                //H314
                if (clickedWord == "Η.314" || clickedWord == "H.314" || clickedWord == "Η314" || clickedWord == "H314" || clickedWord == "Η-314" || clickedWord == "H-314")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H314");
                }

                //H316
                if (clickedWord == "Η.316" || clickedWord == "H.316" || clickedWord == "Η316" || clickedWord == "H316" || clickedWord == "Η-316" || clickedWord == "H-316")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - H316");
                }


                //B301
                if (clickedWord == "Β.301" || clickedWord == "B.301" || clickedWord == "Β301" || clickedWord == "B301" || clickedWord == "Β-301" || clickedWord == "B-301")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B301");
                }

                //B302
                if (clickedWord == "Β.302" || clickedWord == "B.302" || clickedWord == "Β302" || clickedWord == "B302" || clickedWord == "Β-302" || clickedWord == "B-302")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B302");
                }

                //B303
                if (clickedWord == "Β.303" || clickedWord == "B.303" || clickedWord == "Β303" || clickedWord == "B303" || clickedWord == "Β-303" || clickedWord == "B-303")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B303");
                }

                //B304
                if (clickedWord == "Β.304" || clickedWord == "B.304" || clickedWord == "Β304" || clickedWord == "B304" || clickedWord == "Β-304" || clickedWord == "B-304")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B304");
                }

                //B305
                if (clickedWord == "Β.305" || clickedWord == "B.305" || clickedWord == "Β305" || clickedWord == "B305" || clickedWord == "Β-305" || clickedWord == "B-305")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B305");
                }

                //B306
                if (clickedWord == "Β.306" || clickedWord == "B.306" || clickedWord == "Β306" || clickedWord == "B306" || clickedWord == "Β-306" || clickedWord == "B-306")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B306");
                }

                //B307
                if (clickedWord == "Β.307" || clickedWord == "B.307" || clickedWord == "Β307" || clickedWord == "B307" || clickedWord == "Β-307" || clickedWord == "B-307")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B307");
                }

                //B308
                if (clickedWord == "Β.308" || clickedWord == "B.308" || clickedWord == "Β308" || clickedWord == "B308" || clickedWord == "Β-308" || clickedWord == "B-308")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B308");
                }

                //B309
                if (clickedWord == "Β.309" || clickedWord == "B.309" || clickedWord == "Β309" || clickedWord == "B309" || clickedWord == "Β-309" || clickedWord == "B-309")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B309");
                }

                //B310
                if (clickedWord == "Β.310" || clickedWord == "B.310" || clickedWord == "Β310" || clickedWord == "B310" || clickedWord == "Β-310" || clickedWord == "B-310")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B310");
                }

                //B311
                if (clickedWord == "Β.311" || clickedWord == "B.311" || clickedWord == "Β311" || clickedWord == "B311" || clickedWord == "Β-311" || clickedWord == "B-311")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B311");
                }

                //B312
                if (clickedWord == "Β.312" || clickedWord == "B.312" || clickedWord == "Β312" || clickedWord == "B312" || clickedWord == "Β-312" || clickedWord == "B-312")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B312");
                }

                //B313
                if (clickedWord == "Β.313" || clickedWord == "B.313" || clickedWord == "Β313" || clickedWord == "B313" || clickedWord == "Β-313" || clickedWord == "B-313")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B313");
                }

                //B314
                if (clickedWord == "Β.314" || clickedWord == "B.314" || clickedWord == "Β314" || clickedWord == "B314" || clickedWord == "Β-314" || clickedWord == "B-314")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B314");
                }

                //B315
                if (clickedWord == "Β.315" || clickedWord == "B.315" || clickedWord == "Β315" || clickedWord == "B315" || clickedWord == "Β-315" || clickedWord == "B-315")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B315");
                }

                //B316
                if (clickedWord == "Β.316" || clickedWord == "B.316" || clickedWord == "Β316" || clickedWord == "B316" || clickedWord == "Β-316" || clickedWord == "B-316")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B316");
                }

                //B317
                if (clickedWord == "Β.317" || clickedWord == "B.317" || clickedWord == "Β317" || clickedWord == "B317" || clickedWord == "Β-317" || clickedWord == "B-317")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B317");
                }

                //B318
                if (clickedWord == "Β.318" || clickedWord == "B.318" || clickedWord == "Β318" || clickedWord == "B318" || clickedWord == "Β-318" || clickedWord == "B-318")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B318");
                }

                //B319
                if (clickedWord == "Β.319" || clickedWord == "B.319" || clickedWord == "Β319" || clickedWord == "B319" || clickedWord == "Β-319" || clickedWord == "B-319")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B319");
                }

                //B320
                if (clickedWord == "Β.320" || clickedWord == "B.320" || clickedWord == "Β320" || clickedWord == "B320" || clickedWord == "Β-320" || clickedWord == "B-320")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B320");
                }

                //B321
                if (clickedWord == "Β.321" || clickedWord == "B.321" || clickedWord == "Β321" || clickedWord == "B321" || clickedWord == "Β-321" || clickedWord == "B-321")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B321");
                }

                //B322
                if (clickedWord == "Β.322" || clickedWord == "B.322" || clickedWord == "Β322" || clickedWord == "B322" || clickedWord == "Β-322" || clickedWord == "B-322")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B322");
                }

                //B323
                if (clickedWord == "Β.323" || clickedWord == "B.323" || clickedWord == "Β323" || clickedWord == "B323" || clickedWord == "Β-323" || clickedWord == "B-323")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B323");
                }

                //B325
                if (clickedWord == "Β.325" || clickedWord == "B.325" || clickedWord == "Β325" || clickedWord == "B325" || clickedWord == "Β-325" || clickedWord == "B-325")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B325");
                }

                //B327
                if (clickedWord == "Β.327" || clickedWord == "B.327" || clickedWord == "Β327" || clickedWord == "B327" || clickedWord == "Β-327" || clickedWord == "B-327")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B327");
                }

                //B329
                if (clickedWord == "Β.329" || clickedWord == "B.329" || clickedWord == "Β329" || clickedWord == "B329" || clickedWord == "Β-329" || clickedWord == "B-329")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - B329");
                }



                //K301
                if (clickedWord == "Κ.301" || clickedWord == "K.301" || clickedWord == "Κ301" || clickedWord == "K301" || clickedWord == "Κ-301" || clickedWord == "K-301")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K301");
                }

                //K302
                if (clickedWord == "Κ.302" || clickedWord == "K.302" || clickedWord == "Κ302" || clickedWord == "K302" || clickedWord == "Κ-302" || clickedWord == "K-302")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K302");
                }

                //K303
                if (clickedWord == "Κ.303" || clickedWord == "K.303" || clickedWord == "Κ303" || clickedWord == "K303" || clickedWord == "Κ-303" || clickedWord == "K-303")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K303");
                }

                //K304
                if (clickedWord == "Κ.304" || clickedWord == "K.304" || clickedWord == "Κ304" || clickedWord == "K304" || clickedWord == "Κ-304" || clickedWord == "K-304")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K304");
                }

                //K305
                if (clickedWord == "Κ.305" || clickedWord == "K.305" || clickedWord == "Κ305" || clickedWord == "K305" || clickedWord == "Κ-305" || clickedWord == "K-305")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K305");
                }

                //K306
                if (clickedWord == "Κ.306" || clickedWord == "K.306" || clickedWord == "Κ306" || clickedWord == "K306" || clickedWord == "Κ-306" || clickedWord == "K-306")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K306");
                }

                //K307
                if (clickedWord == "Κ.307" || clickedWord == "K.307" || clickedWord == "Κ307" || clickedWord == "K307" || clickedWord == "Κ-307" || clickedWord == "K-307")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K307");
                }

                //K308
                if (clickedWord == "Κ.308" || clickedWord == "K.308" || clickedWord == "Κ308" || clickedWord == "K308" || clickedWord == "Κ-308" || clickedWord == "K-308")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K308");
                }

                //K309
                if (clickedWord == "Κ.309" || clickedWord == "K.309" || clickedWord == "Κ309" || clickedWord == "K309" || clickedWord == "Κ-309" || clickedWord == "K-309")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K309");
                }

                //K310
                if (clickedWord == "Κ.310" || clickedWord == "K.310" || clickedWord == "Κ310" || clickedWord == "K310" || clickedWord == "Κ-310" || clickedWord == "K-310")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K310");
                }

                //K311
                if (clickedWord == "Κ.311" || clickedWord == "K.311" || clickedWord == "Κ311" || clickedWord == "K311" || clickedWord == "Κ-311" || clickedWord == "K-311")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K311");
                }

                //K312
                if (clickedWord == "Κ.312" || clickedWord == "K.312" || clickedWord == "Κ312" || clickedWord == "K312" || clickedWord == "Κ-312" || clickedWord == "K-312")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K312");
                }

                //K313
                if (clickedWord == "Κ.313" || clickedWord == "K.313" || clickedWord == "Κ313" || clickedWord == "K313" || clickedWord == "Κ-313" || clickedWord == "K-313")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K313");
                }

                //K314
                if (clickedWord == "Κ.314" || clickedWord == "K.314" || clickedWord == "Κ314" || clickedWord == "K314" || clickedWord == "Κ-314" || clickedWord == "K-314")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K314");
                }

                //K315
                if (clickedWord == "Κ.315" || clickedWord == "K.315" || clickedWord == "Κ315" || clickedWord == "K315" || clickedWord == "Κ-315" || clickedWord == "K-315")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K315");
                }

                //K316
                if (clickedWord == "Κ.316" || clickedWord == "B.K316" || clickedWord == "Κ316" || clickedWord == "K316" || clickedWord == "Κ-316" || clickedWord == "K-316")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K316");
                }

                //K317
                if (clickedWord == "Κ.317" || clickedWord == "K.317" || clickedWord == "Κ317" || clickedWord == "K317" || clickedWord == "Κ-317" || clickedWord == "K-317")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K317");
                }

                //K319
                if (clickedWord == "Κ.319" || clickedWord == "K.319" || clickedWord == "Κ319" || clickedWord == "K319" || clickedWord == "Κ-319" || clickedWord == "K-319")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K319");
                }

                //K321
                if (clickedWord == "Κ.321" || clickedWord == "K.321" || clickedWord == "Κ321" || clickedWord == "K321" || clickedWord == "Κ-321" || clickedWord == "K-321")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K321");
                }

                //K323
                if (clickedWord == "Κ.323" || clickedWord == "K.323" || clickedWord == "Κ323" || clickedWord == "K323" || clickedWord == "Κ-323" || clickedWord == "K-323")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K323");
                }

                //K325
                if (clickedWord == "Κ.325" || clickedWord == "K.325" || clickedWord == "Κ325" || clickedWord == "K325" || clickedWord == "Κ-325" || clickedWord == "K-325")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K325");
                }

                //K327
                if (clickedWord == "Κ.327" || clickedWord == "B.K327" || clickedWord == "Κ327" || clickedWord == "K327" || clickedWord == "Κ-327" || clickedWord == "K-327")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K327");
                }

                //K329
                if (clickedWord == "Κ.329" || clickedWord == "K.329" || clickedWord == "Κ329" || clickedWord == "K329" || clickedWord == "Κ-329" || clickedWord == "K-329")
                {
                    targetObject = waypoints.Find(obj => obj.name == "GameObject - K329");
                }


                if (targetObject != null && player != null)
                {
                    WaypointSystem waypointSystem = player.GetComponent<WaypointSystem>();
                    if (waypointSystem != null)
                    {
                        waypointSystem.SetLatestMenu(panel);
                        Transform s = targetObject.transform.GetChild(0).GetChild(2);
                        waypointSystem.SetTarget(s);
                    }
                }
            }
            teach = 0;
        }
    }
}
