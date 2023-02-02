#ifndef __Input_h
#define __Input_h
#include "Timer.h"

typedef void (*InputHandle) (void);
class MyInput
{
   public:
   bool flag_toogle = false;
   bool State = false;
   void Init(int PIN_Num);
   void Set_toggle(bool value);
   void GetState(int Time);
   void GetState();
   int OnDelayTime = -1;
   int OnDelayTime_buf = -2;
   int OffDelayTime = -1;
   int OffDelayTime_buf = -2;
   InputHandle Input_ON = nullptr;
   InputHandle Input_OFF = nullptr;
   private:  
   bool flag_state = false;
   int PIN_NUM = -1;
   int cnt_on = 1;
   int cnt_off = 1;
   MyTimer myTimer;
};


#endif
