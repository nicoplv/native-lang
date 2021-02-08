#import "Foundation/Foundation.h"
#import "IOSNativeLang.h"
#import "UIKit/UIKit.h"
#import "GameKit/GameKit.h"

@implementation IOSNativeLang

+ (IOSNativeLang *)instance
{
    static IOSNativeLang *instance = nil;
    if( !instance )
        instance = [[IOSNativeLang alloc] init];
    return instance;
}

- (char *) getSysLang
{
    NSString *lang = [[NSLocale preferredLanguages] objectAtIndex:0];
    
    return [[IOSNativeLang instance] cStringCopy : [lang UTF8String]];
}

- (char *) cStringCopy : (const char *) str
{
    if(str == NULL)
    {
        return NULL;
    }
    
    char * res = (char *)malloc(strlen(str) + 1);
    
    strcpy(res, str);
    
    return res;
}
@end
