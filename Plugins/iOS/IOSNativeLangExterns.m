#import "IOSNativeLang.h"

char *GetSysLang()
{
    char *lang = [[IOSNativeLang instance] getSysLang];
    
    return lang;
}